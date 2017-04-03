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
               timeRemaining = globalData.timeNeededToGetCoins;

               playButtonText.text = "Play anyway";
          } else {
               noRewardsImage.SetActive(false);
               if (globalData.levelNumber == 1) {
                    backButton.SetActive (false);
               } else {
                    backButton.SetActive (true);
               }

               if (globalData.coins_condition) {
                    infoText.text = "Win coins" + "\n" +  "by reaching the goal speedily and avoiding enemies !";
               } else {
                    infoText.text = "Reach the goal as fast you can avoiding wacky enemies on your way !";
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

               infoText.text = "No coins for this level now" + "\n" + "To get coins come back in" + "\n" + timeInMin.ToString () + " min " + timeInSec.ToString () + " sec";
          }
		
	}
     public void SetThankYouPopup() {
          thankYouPopup.SetActive (true);
     }
}
