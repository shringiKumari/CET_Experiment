using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackOnClick : MonoBehaviour {

	// Use this for initialization
     public StoreMotivationData storeMotivationData;
     private string motivationJson;

     public GameObject thankYouPopup;
     public RewardsInfoPopupSetup rewardInfoSetup;
     public Transform playAnywayButton;

     private GlobalData globalData;

     void Start () {
          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick() {

          Debug.Log ("back click");
          rewardInfoSetup.StoreMotivationData(1);
          Analytics.LogCritical ("Level Number", globalData.levelNumber + "");
          //Analytics.LogCritical ("Level Number", globalData.coins_experiment + "");
          //Analytics.LogCritical ("Test", 500 + "");
          //store that back was clicked
          motivationJson = storeMotivationData.GetJsonString();

          Analytics.LogCritical ("JsonTest", motivationJson);
          Debug.Log (motivationJson);
          //storeMotivationData.OnProgress(globalData.levelNumber, globalData.coins_experiment, globalData.coins_condition, infoStateString, globalData.timeNeededToGetCoins - timeRemaining, globalData.totalCoinsEarned);


          playAnywayButton.GetComponent<Button>().interactable = false;
         

          //thankYouPopup.SetActive(true);
     }
}
