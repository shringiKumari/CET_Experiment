using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RewardsInfoPopupSetup : MonoBehaviour {

     private GlobalData globalData;
     public int firstNoRewardLevel;
     public GameObject noRewardsImage;
     public GameObject backButton;
     public Text infoText;
     public Text playButtonText;
     // Use this for initialization
	void Start () {
          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
          if ((globalData.levelNumber > firstNoRewardLevel) && (globalData.coins_condition == true)) {
               //coin image set active
               noRewardsImage.SetActive(true);
               //back button set active
               backButton.SetActive(true);
               // text = no more rewards
               infoText.text = "Come Later";
               playButtonText.text = "Play anyway";
               Debug.Log("no rewards");
          } else {
               //coin image set inactive
               noRewardsImage.SetActive(false);
               //back button set inactive
               backButton.SetActive(false);
               // text = rewards  
               if (globalData.coins_condition) {
                    infoText.text = "Play the game, get coins";
               } else {
                    infoText.text = "Play the game";
               }
               playButtonText.text = "Play";
               Debug.Log("rewards");
          }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
