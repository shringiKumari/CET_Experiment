using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadScene : MonoBehaviour {

     public Pauser pause;
     public LevelNumberText levelNumberText;
     public ButtonText buttonText;
     public Level_HUD levelHUDText;
     public Text feedbackText;

     [SerializeField] private GameObject levelStart;
     [SerializeField] private GameObject score;
     [SerializeField] private GameObject coins;
     [SerializeField] private GameObject noRewardsPopup;
     [SerializeField] private GameObject thankYouPopup;

     string[] positiveFeedback = new string[] {"Well Don!", "Good Job!", "Sweeet Score!"};
     string[] neutralFeedback = new string[] {"You Scored", "You Scored", "Complete"};
     private GlobalData globalData;


     public StoreAttempt store;
	// Use this for initialization
	void Start () {

          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
          List<Attempts.AttemptModel> allAttempts = store.GetCurrentAttemptData ();
          if (allAttempts != null) {
               int currentAttempt = allAttempts.Count - 1;
               bool gameWin = allAttempts [currentAttempt].win;

               if (gameWin) {
                    levelNumberText.SetLevelNumber (globalData.levelNumber, globalData.maxLevel);
                    buttonText.SetButtonText (globalData.levelNumber, globalData.maxLevel);
                    globalData.levelNumber++;
                    levelHUDText.SetLevelHUDNumber (globalData.levelNumber);
                    levelStart.SetActive (true);
                    pause.Pause (true);
                    if ((globalData.coins_condition) && (globalData.levelNumber <= globalData.firstNoRewardLevel) ) {
                         coins.SetActive (true);
                    } else {
                         coins.SetActive (false);

                    }
                    if (globalData.levelNumber > globalData.maxLevel) {
                         Transform upgrade = coins.transform.FindChild ("Upgrade");
                         if (upgrade != null) {
                              upgrade.gameObject.SetActive (false);
                         }
                    }
                    if (!globalData.coins_experiment) {
                         switch (globalData.feedbackCondition) {
                         case Feedback_Condition.FEEDBACK_ON:
                              //feedbackText.text = "WELL DONE!"; 
                              feedbackText.text = positiveFeedback[Random.Range(0,2)]; 
                              break;
                         case Feedback_Condition.FEEDBACK_OFF:
                              feedbackText.text = ""; 
                              break;
                         case Feedback_Condition.FEEDBACK_NEUTRAL:
                              feedbackText.text = neutralFeedback[Random.Range(0,2)]; 
                              break;
                         }
                    }


               } else {
                    levelStart.SetActive (false);
               }
          } else {
               if (globalData.coins_experiment) {
                    Debug.Log ("coins experiment");
                    noRewardsPopup.SetActive (true);
                    pause.Pause (true);
               } else {
                    levelStart.SetActive (false);
               }

               levelNumberText.SetLevelNumber (globalData.levelNumber, globalData.maxLevel);


          }


	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick () {

          pause.Pause (false);
          if (globalData.levelNumber > globalData.maxLevel) {
          // show thank you popup
               thankYouPopup.SetActive(true);
          }

          if (globalData.coins_experiment) {
               pause.Pause (true);
               noRewardsPopup.SetActive (true);
          } else {

               levelStart.SetActive (false);
          }

     }
}
