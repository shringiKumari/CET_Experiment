using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class Analytics : MonoBehaviour
{

    public static Analytics INSTANCE; // Singleton instance identifier for grabbing this object

    public bool LoggingLocationSet = false; // This is set to true when users select to either log remotely or locally
    public bool LogToDisk = true; // This variable records whether users want to log locally or remotely

    public bool PHPGenerated = false; // This is set to true when users have generated PHP code for running TestTube on a remote server.
    public bool WizardCompleted = false; // This is set to true when users have finished the setup wizard for their servers

    /*
     * These variables hold information which is used to generate PHP files. These files are placed on a server, and allow
     * Unity to store data in a remote database. 
     */

    public string DBHostname = "enter hostname here";
    public string DBPort = "3306";
    public string DBUserName = "enter username here";
    public string DBPassword = "";
    public string DBName = "ebdb";


    public int NumberOfConditions = 1; // If you are running an experiment, how many conditions does your experiment have?

    /*
     * These variables hold information about the games that data can be logged for.
     * GameNameID maps the name of games to integers representing their unique identifiers within a database
     * GameNames holds a list of strings representing different games, from which the user can pick a game to record data for
     * SelectedGameOption holds the currently selected game to log data for
     * NewGameName allows users to specify the name of a new game for which to log data
     */

    public Dictionary<string,int> GameNameID = new Dictionary<string,int> ();
	public string[] GameNames = new string[0];
	public int SelectedGameOption  = 0;
	public string NewGameName = "";

	//These flags are used to stop multiple instances of the same coroutine from running simultaneously.
	public bool SetSessionFlag = false;
	public bool PushSessionParametersFlag = false;

    public int gameID = -1; // What is the ID of the game that is currently being logged? Set to -1 by default; is set to a positive value when a game is selected.
    public GameplaySession Session; // The current session that a player is engaged in. Holds a unique ID, as well as demographic and condition data.
    public bool SessionSet = false; // Has the session been set? Is flagged as 'true' after informed consent is given.

    /*
     * The base domain URL is set during a setup wizard: All other URLs for the game to communicate with are formed by appending strings to this base.
     */

        

    public string BaseDomainURL; // Override this BaseDomainURL if you don't want to use the wizard



    string SetSessionIDURL;
    string PushSessionParametersURL;
    string GetEventIDsURL;
    string PushEventInformationURL;
    string PushCriticalEventURL;

    /*
     * Change these php files if you are using a custom setup on your server
     */

     string LocalSetSessionIDURL = "SetSessionID.php";
     string LocalPushSessionParametersURL = "PushSessionParameters.php";
     string LocalGetTraceIDsURL = "GetTraceIDs.php";
     string LocalPushEventInformationURL = "PushTraceInformation.php";
     string LocalPushCriticalEventURL = "PushCriticalEvent.php";


    /*
     * A big list of events. These are 'popped' off the stack every time confirmation
     * comes from the server that they are logged.
     */

    public List<EventData> Events = new List<EventData>();
    public List<EventData> CriticalEvents = new List<EventData>();


    #region General

    // Method which returns true if Analytics actually exists

    public static bool NotNull()
    {
        return INSTANCE != null;
    }

    //static method which grabs main analytics object
    public static Analytics Get()
    {
        return Analytics.INSTANCE;
    }

    #endregion

    #region Local Setup Session Alternatives

    /*
     * This code is relevant if you are logging local data
     */


    public void SetLocalSession()
    {

        /*
        * Define and record session parameters for logging to local logs 
        */

    
        string localSessionLocation = "Logs/LastSession.txt";
        int sessionID = 0;






        if (File.Exists(localSessionLocation))
        {
            string s = File.ReadAllText(localSessionLocation);
            File.Delete(localSessionLocation);
            sessionID = int.Parse(s);
            sessionID += 1;
        }


        File.WriteAllText(localSessionLocation, sessionID + "");

        Session = new GameplaySession(sessionID, 0);
        SessionSet = true;  //Flags that session is now running

        int condition;
        if (NumberOfConditions > 0)
        {
            condition = UnityEngine.Random.Range(0, NumberOfConditions);
        }
        else
        {
            condition = 0;
        }


        Analytics.Get().Session.AddInfo("Condition", "" + condition);

    }

    public void PushLocalSessionParameters()
    {


        if (!SessionSet)
        {
            //Debug.LogError("Trying to push local session parameters before a session is set!");
        }


        List<Information> parameters = new List<Information>();
        parameters.AddRange(Session.DemographicsAnswers);
        parameters.AddRange(Session.AdditionalInformation);

        int count = parameters.Count;

        int session = Session.ID;
        string[] input = new string[count];

        for (int i = 0; i < count; i++)
        {

            Information information = parameters[i];

            input[i] = information.title + "\t" + information.info;


        }

        string outfile = "Logs/Parameters_" + session + ".txt";


        using (var file = new StreamWriter(outfile, true))
        {
            foreach (var row in input)
            {
                file.WriteLine(row);
            }
        }


        Session.InformationPushed = true;

    }

    #endregion

    #region Setup Session

    //Method which begins a new session; never directly called by the user
    //This is called when informed consent has been accepted.

    public void SetSession()
    {

        if (SetSessionFlag == false)
        {

            SetSessionFlag = true;

            if (!LogToDisk) { 
            StartCoroutine(SetSession_coroutine());
            }
            else
            {
                SetLocalSession();
            }

        }
    }

    // Background coroutine which sets up a session
    public IEnumerator SetSession_coroutine()
    {


        WWWForm form = new WWWForm();
        form.AddField("gameID", this.gameID);

        WWW www = new WWW(SetSessionIDURL, form);

        yield return www;

        Session = new GameplaySession(int.Parse(www.text), this.gameID);
        SessionSet = true;  //Flags that session is now running

        int condition;


        /*
         * Randomly allocate participants a condition
         */

        if (NumberOfConditions > 0)
        {
            condition = UnityEngine.Random.Range(0, NumberOfConditions);
        }
        else
        {
            condition = 0;
        }
       
        // Records the condition that the participant is in
        Analytics.LogWithTimestamp("Condition", "" + condition);


    }


    #endregion

    #region Local Logging Alternatives

    private int EventID = 0;

    public IEnumerator PushLocalEvents_coroutine()
    {

        /*
         * First, wait until the analytics object has had its session number assigned
         */

        if (!Analytics.INSTANCE.SessionSet)
        {
            //Debug.LogError("Trying to push local events before session is set");
        }



        int session = this.Session.ID;


        while (true)
        {

       
            /*
             * If there are no events to log, idle
             */

            while (Events.Count == 0)
            {
                yield return new WaitForSeconds(0.1f);
            }

            /*
             * When an event to log appears in the list, first create
             * arrays to hold the information pertinent to the event,
             * then add this data to a form
             */

            EventData e = Events[0];
            List<int> id = new List<int>();
            List<string> title = new List<string>();
            List<string> info = new List<string>();

            for (int j = 0; j < e.info.Count; j++)
            {
                Information information = e.info[j];
                title.Add(information.title);
                info.Add(information.info);
                id.Add(EventID);
            }


            string[] input = new string[id.Count];


            for (int i = 0; i < input.Length; i++)
            {


                input[i] = id[i] + "\t" + title[i]+"\t"+info[i];


            }

            string outfile = "Logs/Events_" + session + ".txt";


            using (var file = new StreamWriter(outfile, true))
            {
                foreach (var row in input)
                {
                    file.WriteLine(row);
                }
            }



           Events.RemoveAt(0);
           EventID += 1;

            yield return null;

        }
    }


    #endregion

    #region Logging

    /*
     * 
     * Helper methods for recording common things
     * 
     */

    //Record an event with a timestamp
    public static void LogWithTimestamp(string title, string info)
    {
        if (Analytics.NotNull()) { 
            AddEvent(new EventData(new Information[] { Information.time, new Information(title, info)}));
        }
    }

    public static void LogCritical(string title, string info)
    {
        if (Analytics.NotNull())
        {

            Debug.Log ("LogCriticalNotNull");
            AddCriticalEvent(new EventData(new Information[] { Information.time, new Information(title, info) }));
        }

    }

    public static void LogEvent(EventData e)
    {
        if (Analytics.NotNull())
        {

            AddEvent(e);

        }

    }

    public static void LogTransform(Transform t, bool timestamp = true)
    {

        if (Analytics.NotNull())
        {

            Information gameobject = new Information("gameobject", t.gameObject + "");

            Information rotation = new Information("rotation", t.rotation.eulerAngles + "");
            Information position = new Information("position", t.position + "");
            Information scale = new Information("scale", t.localScale + "");

            if (timestamp)
            {
                AddEvent(new EventData(

                    new Information[] { gameobject, Information.time, rotation, position, scale }


                ));
            }
            else
            {
                AddEvent(new EventData(
                                        new Information[] { gameobject, rotation, position, scale }
                                        ));
            }

        }
    }


    #endregion


    //Helper method for single-factor experiments - returns the condition for these.

    private static int _condition = -1;

    public static int condition
    {
        get
        {

            if (Analytics.NotNull())
            {
                if (_condition == -1) { 

                List<Information> infoList = Analytics.Get().Session.AdditionalInformation;

                foreach (Information info in infoList)
                {

                    if (info.title == ("Condition"))
                    {
                        _condition = int.Parse(info.info); break;
                    }

                }


              }

                return _condition;
            }
            else
            {

                return 0; // If analytics does not exist, return 0
            }

        }
    }


    void Awake ()
	{

        if (LogToDisk)
        {
            Directory.CreateDirectory("Logs");
        }

		if (INSTANCE != null) {
			GameObject.Destroy (this.gameObject);
		} else {

            INSTANCE = this;

            DontDestroyOnLoad(transform.gameObject);

            /*
             * Set paths for talking to PHP scripts on the server
             */

			SetSessionIDURL = BaseDomainURL + LocalSetSessionIDURL;
			PushSessionParametersURL = BaseDomainURL + LocalPushSessionParametersURL;

            GetEventIDsURL = BaseDomainURL + LocalGetTraceIDsURL;
			PushEventInformationURL = BaseDomainURL + LocalPushEventInformationURL;
            PushCriticalEventURL = BaseDomainURL + LocalPushCriticalEventURL;

            /*
             * Grab a unique session identifier
             */

            SetSession();

            /*
             * Start the coroutine cycle for pushing new events to an output queue
             */

            if (!LogToDisk)
            {
                StartCoroutine(PushEvents_coroutine());
                StartCoroutine(PushCriticalEvents_coroutine());

            }
            else
            {
                StartCoroutine(PushLocalEvents_coroutine());
            }

        }


    }

    

	public static void AddEvent (EventData trace)
	{

		INSTANCE.Events.Add (trace);

	}

    public static void AddCriticalEvent(EventData trace)
    {
        Debug.Log ("AddCriticalEventTrace");
        INSTANCE.CriticalEvents.Add(trace);
        Debug.Log ("" + INSTANCE.CriticalEvents.Count);

    }


     public void Update(){


     }

    private List<int> ParseEventIDs(string s)
    {
    
        /*
         * Get an array of numbers from the server, and parse this list
         * to determine legal IDs for upcoming events
         */
            
        string[] sArray = s.Split(",".ToCharArray());

        List<int> eventIDList = new List<int>();

        for (int i = 0; i < sArray.Length; i++)
        {
            eventIDList.Add(int.Parse(sArray[i]));
        }

        return eventIDList;

    }

    public IEnumerator PushCriticalEvents_coroutine()
    {


        /*
         * First, wait until the analytics object has had its session number assigned
         */

        while (!Analytics.INSTANCE.SessionSet)
        {
            yield return null;

               //Debug.Log ("SESSIONNOTSET");
        }

        int session = this.Session.ID;

        while (true)
        {

            /*
             * If there are no events to log, idle
             */

            while (CriticalEvents.Count == 0)
            {
                yield return new WaitForSeconds(0.1f);
            
                    //Debug.Log ("CRITICALEVENTSAT0");
               
               }


            /*
             * When an event to log appears in the list, first create
             * arrays to hold the information pertinent to the event,
             * then add this data to a form
             */

            EventData e = CriticalEvents[0];

            string title = e.info[1].title;
            string info = e.info[1].info;

            CriticalEvents.RemoveAt(0);

            WWWForm form = new WWWForm();
            
                form.AddField("title[]", title);
                form.AddField("info[]", info);
            form.AddField("session", session);
           
            Debug.Log ("Coroutine running");

            StartCoroutine(PushCriticalEvent(form));

        }


    }



    public IEnumerator PushEvents_coroutine()
    {

        /*
         * First, wait until the analytics object has had its session number assigned
         */

        while (!Analytics.INSTANCE.SessionSet)
        {
            yield return null;
        }



        int session = this.Session.ID;


        /*
         * This form will be used to grab new valid IDs for events
         */

        WWWForm getNewEventIDsForm = new WWWForm();
        getNewEventIDsForm.AddField("session", session);
        getNewEventIDsForm.AddField("length", 30);

        List<int> validEventIDs = new List<int>();


        while (true)
        {


            /*
             * If you're out of valid IDs to attach to your events, grab more from the server
             */

            if (validEventIDs.Count == 0)
            {
                WWW www = new WWW(GetEventIDsURL, getNewEventIDsForm);
                yield return www;
                string s = www.text;
                validEventIDs = ParseEventIDs(s);
            }

            /*
             * If there are no events to log, idle
             */

            while (Events.Count == 0)
            {
                yield return new WaitForSeconds(0.1f);
            }

            /*
             * When an event to log appears in the list, first create
             * arrays to hold the information pertinent to the event,
             * then add this data to a form
             */

            EventData e = Events[0];
            List<int> id = new List<int>();
            List<string> title = new List<string>();
            List<string> info = new List<string>();

            for (int j = 0; j < e.info.Count; j++)
            {
                Information information = e.info[j];
                title.Add(information.title);
                info.Add(information.info);
                id.Add(validEventIDs[0]);
            }

            WWWForm form = new WWWForm();

            for (int i = 0; i < id.Count; i++)
            {
                form.AddField("trace_id[]", id[i]);
                form.AddField("title[]", title[i]);
                form.AddField("info[]", info[i]);
            }


            Events.RemoveAt(0); validEventIDs.RemoveAt(0);

            StartCoroutine(PushSingleEvent(form));



            //   yield return null;

        }
    }

    public IEnumerator PushSingleEvent(WWWForm form){

        bool success = false;

        while (!success)
        {


            WWW www = new WWW(PushEventInformationURL, form);

            yield return www;

            if (www.text.Contains("Commit"))
            {
                success = true;
            }

        }

    }

    public IEnumerator PushCriticalEvent(WWWForm form)
    {

        bool success = false;
        Debug.Log ("Pushing critical event");
        while (!success)
        {

            WWW www = new WWW(PushCriticalEventURL, form);



            yield return www;


            if (www.text.Contains("Commit"))
            {

                Debug.Log ("Critical event pushed");
                success = true;
            }

        }

    }


}