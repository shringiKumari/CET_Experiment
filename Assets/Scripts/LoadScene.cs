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

     public int maxLevel;
     public int firstNoRewardLevel;
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
                    levelNumberText.SetLevelNumber (globalData.levelNumber, maxLevel);
                    buttonText.SetButtonText (globalData.levelNumber, maxLevel);
                    globalData.levelNumber++;
                    levelHUDText.SetLevelHUDNumber (globalData.levelNumber);
                    levelStart.SetActive (true);
                    pause.Pause (true);
                    if (globalData.coins_condition) {
                         coins.SetActive (true);
                    } else {
                         coins.SetActive (false);

                    }
                    if (globalData.levelNumber > maxLevel) {
                         Transform upgrade = coins.transform.FindChild ("Upgrade");
                         if (upgrade != null) {
                              upgrade.gameObject.SetActive (false);
                         }
                    }
                    switch (globalData.feedbackCondition) {
                    case Feedback_Condition.FEEDBACK_ON:
                         feedbackText.text = "WELL DONE!"; 
                         break;
                    case Feedback_Condition.FEEDBACK_OFF:
                         feedbackText.text = ""; 
                         break;
                    case Feedback_Condition.FEEDBACK_NEUTRAL:
                         feedbackText.text = "LEVEL COMPLETE"; 
                         break;
                    }



               } else {
                    levelStart.SetActive (false);
               }
          } else {
               //levelStart.SetActive (false);
               noRewardsPopup.SetActive (true);
               //pause.Pause (true);
               levelNumberText.SetLevelNumber (globalData.levelNumber, maxLevel);


          }


	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick () {

          pause.Pause (false);
          if (globalData.levelNumber > maxLevel) {
          Debug.Log ("Application Quit");
          Application.Quit ();
          }

          if (globalData.coins_condition == true) {
               pause.Pause (true);
               noRewardsPopup.SetActive (true);
          } else {

               levelStart.SetActive (false);
          }

     }
}
