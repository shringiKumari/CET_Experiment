using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Feedback_Condition{
     FEEDBACK_ON,
     FEEDBACK_OFF,
     FEEDBACK_NEUTRAL     
};


public class GlobalData : MonoBehaviour {

     public int levelNumber = 1;
     public int levelTimeScore;
     public int levelHealthScore;
     public int totalCoinsEarned = 0;

     public bool coins_condition;
     public Feedback_Condition feedbackCondition;

     // Use this for initialization
	void Start () {
		
	}

     void Awake () {
          DontDestroyOnLoad (gameObject);

     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
