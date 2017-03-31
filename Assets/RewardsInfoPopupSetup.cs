using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RewardsInfoPopupSetup : MonoBehaviour {

     private GlobalData globalData;
     public GameObject noRewardsImage;
     public GameObject backButton;
     public GameObject thankYouPopup;
     public Text infoText;
     public Text playButtonText;

     private float startTime = 0;
     private float timeNeededToGetCoins = 30;
     private float timeRemaining;
     private int timeInMin;
     private float timeInSec;
     private string timeGap;
     // Use this for initialization
	void Start () {
          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
          if ((globalData.levelNumber >= globalData.firstNoRewardLevel) && (globalData.coins_condition == true)) {
               noRewardsImage.SetActive(true);
               backButton.SetActive(true);
               timeRemaining = timeNeededToGetCoins;
               playButtonText.text = "Play anyway";
          } else {
               noRewardsImage.SetActive(false);
               backButton.SetActive(false);
               if (globalData.coins_condition) {
                    infoText.text = "Play the game, get coins";
               } else {
                    infoText.text = "Play the game";
               }
               playButtonText.text = "Play";
          }
		
	}
	
	// Update is called once per frame
	void Update () {

          if ((globalData.levelNumber >= globalData.firstNoRewardLevel) && (globalData.coins_condition == true)) {

               if (timeRemaining > 0) {
                    timeInMin = Mathf.FloorToInt (timeRemaining / 60);
                    timeInSec = Mathf.FloorToInt (timeRemaining % 60);
                    timeRemaining -= Time.unscaledDeltaTime;
               } else {
                    SetThankYouPopup ();
               }

               infoText.text = "Come Later" + " " + timeInMin.ToString () + " min " + timeInSec.ToString () + " sec";
          }
		
	}
     public void SetThankYouPopup() {
          thankYouPopup.SetActive (true);
     }
}
