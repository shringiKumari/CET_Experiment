using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LikertPanel : MonoBehaviour {

    public Scrollbar Scroll;
    private Transform trialTarget;
    private bool centringOnTrial = false;

    private float timeFirstAnswered = -1f;

    private class LikertItem{
		
		public string Question;
		public bool Reversed;
		public string LeftSide, RightSide;
        public int OriginalIndex;


		public LikertItem(string question, string left, string right, int originalindex){
			Question = question;
			LeftSide = left;
			RightSide = right;
            OriginalIndex = originalindex;
		}

		
	}

	public bool FinalTask = false;

	public GameObject TrialPrefab;
	public GameObject MainPanel;
	public GameObject Mask;

  
    public List<LikertTrial> Trials;

    public string LikertTitle;
	public int NumbersOnLine = 5;
	public string[] Questions;
	public string[] LeftHandText;
	public string[] RightHandText;

	public int NumberOfAnswers;
	public int TotalScore;

    public List<LikertTrial> DoneTrials;

    float Speed;

	// Use this for initialization
	void Start () {

        Speed = 4f / Questions.Length;

		Analytics.LogWithTimestamp ("Likert Task Begun", this.name);
		
		Trials = new List<LikertTrial> ();
        DoneTrials = new List<LikertTrial>();

        PopulateReverseScores();

		List<LikertItem> randomisedList = PopulateRandomQuestionList();
		for (int i = 0; i< randomisedList.Count; i++) {

			LikertItem item = randomisedList[i];

			string question, leftEnd, rightEnd;

			question = item.Question;
			leftEnd = item.LeftSide;
			rightEnd = item.RightSide;

			NewTrial(i, question, leftEnd, rightEnd,item.OriginalIndex);

		}


		
	}


	public void NewTrial(int index, string question, string left, string right,int originalIndex){
		
		GameObject trialObject = GameObject.Instantiate<GameObject> (TrialPrefab);
		trialObject.transform.SetParent (MainPanel.transform);
		LikertTrial t = trialObject.GetComponent<LikertTrial>();
		Trials.Add (t);
		t.Setup(index,question,left,right,this.NumbersOnLine,this,originalIndex);
		
		
		
	}
	





	public void QuestionAnswered(LikertTrial trial, int response){


        if (timeFirstAnswered < 0f)
        {
            timeFirstAnswered = Time.time;
        }

		Trials.Remove (trial);

        if (DoneTrials.Contains(trial) == false)
        {
            DoneTrials.Add(trial);
        }

		if (Trials.Count == 0) {


            foreach(LikertTrial t in DoneTrials){

                Process(t);

            }


            float score = (float)TotalScore / (float)NumberOfAnswers;

			EventData e = new EventData ();

            float calc = Time.time - timeFirstAnswered;

			e.Add ("Timestamp",""+Time.time);
			e.Add ("Likert Task Ended", this.LikertTitle);
			e.Add ("Score",""+score);
            e.Add("Time taken", ""+calc);


            Analytics.LogEvent (e);


			UISequencer.current.Next();
		}
        else
        {
            

            if (trial.Index < MainPanel.transform.childCount-1) { 
            trialTarget = MainPanel.transform.GetChild(trial.Index + 1);
            centringOnTrial = true;
            }
            else if(trial.Index == MainPanel.transform.childCount - 1)
            {
                trialTarget = MainPanel.transform.GetChild(trial.Index-1);
                centringOnTrial = true;
            }




        }

    }


	public void Process(LikertTrial trial){

        int response = trial.Response;

		NumberOfAnswers += 1;

		EventData e = new EventData ();
		e.Add ("Timestamp",""+Time.time);

		e.Add ("Index", trial.Index+"");
        e.Add("Original Index", trial.OriginalIndex + "");
		e.Add ("Question", trial.Stimulus);
		e.Add ("Response", ""+response);
        e.Add(trial.Stimulus, ""+response);

        Analytics.LogEvent (e);

        Analytics.LogCritical(LikertTitle + "_" + trial.OriginalIndex, response + "");

	}
	

	
	void PopulateReverseScores(){
		
		
		if(LeftHandText.Length != Questions.Length){
			string s = LeftHandText[0];
			LeftHandText = new string[Questions.Length];	
			for(int i = 0; i<LeftHandText.Length; i++){LeftHandText[i]=s;}
			
			
		}
		
		if(RightHandText.Length != Questions.Length){
			string s = RightHandText[0];
			RightHandText = new string[Questions.Length];	
			for(int i = 0; i<RightHandText.Length; i++){RightHandText[i]=s;}
			
			
		}


    }
	
	List<LikertItem> PopulateRandomQuestionList(){
		
		List<LikertItem> oldList = new List<LikertItem>(); 
		List<LikertItem> newList = new List<LikertItem>(); 
		
		for(int i = 0; i<Questions.Length; i++){
			oldList.Add (new LikertItem(Questions[i],LeftHandText[i],RightHandText[i],i));
		}
		
		
		while(oldList.Count>0){
			int i = Random.Range (0,oldList.Count);
			newList.Add (oldList[i]);
			oldList.RemoveAt(i);
		}
		
		return newList;
		
	}


    float oldTrialPosition;
    float resetCentring;

    private void Update()
    {

       LikertTrial trialInFocus = null;

        for(int i = 0; i<Trials.Count; i++) {

            LikertTrial lt = Trials[i];
                
            if(lt.transform.position.y<375 && !DoneTrials.Contains(lt)) {

           //     Debug.Log(i + ":" + lt.transform.position.y);

                trialInFocus = lt;
                break;
            }

        }

        if (trialInFocus != null)
        {

            /*
             * Find out if a key has been pressed
             */

            string input = "";
            if (Input.GetKeyDown("1")) { input = "1"; }
            else if (Input.GetKeyDown("2")) { input = "2"; }
            else if (Input.GetKeyDown("3")) { input = "3"; }
            else if (Input.GetKeyDown("4")) { input = "4"; }
            else if (Input.GetKeyDown("5")) { input = "5"; }
            else if (Input.GetKeyDown("6")) { input = "6"; }
            else if (Input.GetKeyDown("7")) { input = "7"; }
            else if (Input.GetKeyDown("8")) { input = "8"; }
            else if (Input.GetKeyDown("9")) { input = "9"; }

            /*
             * A number has been input
             */

            if (input.Length > 0)
            {

                foreach(Transform t in trialInFocus.NumberLine.transform)
                {
                    Text text = t.GetComponentInChildren<Text>();

                    if (text.text.Contains(input))
                    {
                        trialInFocus.Notify(t.gameObject);
                    }

                }

            }


        }

        if (centringOnTrial && Mathf.Abs(trialTarget.transform.position.y - oldTrialPosition) < 5f)
        {
            resetCentring += Time.deltaTime;
        }

        if (!centringOnTrial)
        {
            resetCentring = 0f;
        }

        if (resetCentring > 0.5f)
        {
            centringOnTrial = false;
        }


        if (centringOnTrial)
        {

            oldTrialPosition = trialTarget.transform.position.y;

            if (trialTarget.transform.position.y < (MainPanel.transform.parent.position.y + 40))
            {
                Scroll.value -= (Time.deltaTime * (500f / MainPanel.GetComponent<RectTransform>().rect.height));
            }
            else if (trialTarget.transform.position.y - trialTarget.GetComponent<RectTransform>().rect.height > MainPanel.transform.parent.position.y + (MainPanel.transform.parent.GetComponent<RectTransform>().rect.height / 2f))
            {
                Scroll.value += (Time.deltaTime * (500f / MainPanel.GetComponent<RectTransform>().rect.height));
            }
            else
            {
                centringOnTrial = false;
            }
        }


 
        }

    }



