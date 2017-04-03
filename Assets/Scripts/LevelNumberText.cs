using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberText : MonoBehaviour {

     public Text levelText;
     private GlobalData globalData;

     string[] positiveFeedback = new string[] {"Well Done!", "Good Job!", "You won!"};



     // Use this for initialization
	void Start () {

         //globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();

		
	}

     public void SetLevelNumber (int levelNumber, int maxLevel) {

          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
          if (levelNumber < maxLevel) {
               if (globalData.coins_experiment) {
                    levelText.text = " LEVEL " + levelNumber.ToString () + " complete ";
               } else {
                    switch (globalData.feedbackCondition) {
                    case Feedback_Condition.FEEDBACK_ON:
                         //feedbackText.text = "WELL DONE!"; 
                         levelText.text = positiveFeedback [Random.Range (0, 2)]; 
                         break;
                    case Feedback_Condition.FEEDBACK_OFF:
                         levelText.text = ""; 
                         break;
                    case Feedback_Condition.FEEDBACK_NEUTRAL:
                         levelText.text = " LEVEL " + levelNumber.ToString () + " complete "; 
                         break;
                    }
               }
          } else {
               levelText.text = " GAME COMPLETE ";
          }
          
     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
