using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Feedback_Condition{
     FEEDBACK_ON,
     FEEDBACK_OFF,
     FEEDBACK_NEUTRAL     
};


public class GlobalData : MonoBehaviour {

     public int levelNumber = 0;
     public int levelTimeScore;
     public int levelHealthScore;
     public int totalCoinsEarned = 0;
     public int totalCoinsNeeded;

     public float timeNeededToGetCoins;

     public int firstNoRewardLevel;
     public int maxLevel;

     public bool coins_condition;
     public bool coins_experiment;
     public Feedback_Condition feedbackCondition;
     public bool rewards_expected;
     public bool with_coins;

     private int randomConditionSelector;

     // Use this for initialization
	void Start () {

	}

     void Awake () {
         
          randomConditionSelector = UnityEngine.Random.Range (1, 3);
          switch (randomConditionSelector) {
          case 1:
               coins_condition = true;
               break;
          case 2:
               coins_condition = false;
               break;              
          }
          Debug.Log ("condition" + coins_condition);

          DontDestroyOnLoad (gameObject);

     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
