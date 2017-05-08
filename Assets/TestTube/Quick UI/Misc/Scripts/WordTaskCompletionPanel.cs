using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordTaskCompletionPanel : MonoBehaviour {

	public float TaskTime = 180f;
	public bool FinalTask = true;


	public GameObject MainPanel;
	public GameObject MaskPanel;

	public GameObject TrialPrefab;
	public List<string> Fragments;
	public List<string> TargetResponses;
	public List<string> OffTargetResponses;
	public List<WordTaskTrial> Trials;

	private int totalTrials = 0;
	private int targetTrials = 0;
	private int offTargetTrials = 0;

	// Use this for initialization
	void Start () {
	

		Analytics.LogWithTimestamp ("Word Completion Task Begun", this.name);

		Trials = new List<WordTaskTrial> ();

		for (int i = 0; i< Fragments.Count; i++) {

			string s = Fragments[i];
				
			NewTrial(s,i);

		}

	}
	
	// Update is called once per frame
	void Update () {
		TaskTime -= Time.deltaTime;

		if (TaskTime < 0f) {

			Finish();

		}

	}

	public void Finish(){

		foreach (WordTaskTrial trial in Trials) {

			Process (trial);

		}


		if(FinalTask){
		

			float a = (float)targetTrials;
			float b = (float)offTargetTrials;

            Analytics.LogWithTimestamp("Likert task ended with statistic: ", ((a / (a + b)) + ""));

		
		}

		UISequencer.current.Next ();
	}

	public void Process(WordTaskTrial trial){

		totalTrials += 1;

		EventData e = new EventData ();

		e.Add ("Index", trial.Index+"");
		e.Add ("Fragment", trial.Fragment);
		e.Add ("Response", trial.Response.text);


		if (TargetResponses.Contains (trial.Response.text.ToLower())) {
			targetTrials += 1;
			e.Add ("Result","target");
		} else if (OffTargetResponses.Contains (trial.Response.text.ToLower())) {
			offTargetTrials += 1;
			e.Add ("Result","off-target");

		} else {
			e.Add ("Result","nothing");
		}

		Analytics.AddEvent (e);


	}


	public void NewTrial(string fragmentText, int index){

		GameObject trialObject = GameObject.Instantiate<GameObject> (TrialPrefab);
		trialObject.transform.SetParent (MainPanel.transform);
		WordTaskTrial t = trialObject.GetComponent<WordTaskTrial>();
		Trials.Add (t);
		t.SetParameters(fragmentText,this,index);



	}

}
