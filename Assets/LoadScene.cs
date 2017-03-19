using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadScene : MonoBehaviour {

     public Pauser pause;
     public LevelNumberText levelNumberText;
     [SerializeField] private GameObject levelStart;
    [SerializeField] private GameObject score;
     [SerializeField] private GameObject coins;
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
                    levelNumberText.SetLevelNumber (globalData.levelNumber);
                    globalData.levelNumber++;
                    levelStart.SetActive (true);
                    pause.Pause (true);
                    if (globalData.coins_condition) {
                         coins.SetActive (true);
                    } else {
                         coins.SetActive (false);
                    }
                    switch (globalData.feedbackCondition) {
                    case Feedback_Condition.FEEDBACK_ON:
                         Debug.Log ("Feedback On"); break;
                    case Feedback_Condition.FEEDBACK_OFF:
                         Debug.Log ("Feedback Off"); break;
                    case Feedback_Condition.FEEDBACK_NEUTRAL:
                         Debug.Log ("Feedback Neutral"); break;
                    }


               } else {
                    levelStart.SetActive (false);
               }
          } else {
               levelStart.SetActive (false);
               //pause.Pause (true);
               levelNumberText.SetLevelNumber (globalData.levelNumber);


          }


	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick () {

            pause.Pause (false);
		  levelStart.SetActive(false);

     }
}
