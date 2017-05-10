using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BackOnClick : MonoBehaviour {

	// Use this for initialization
     public StoreMotivationData storeMotivationData;
     private string motivationJson;

     public GameObject thankYouPopup;
     public GameObject quitPopup;

     public Text backButtonText;

     public RewardsInfoPopupSetup rewardInfoSetup;
     public Transform playAnywayButton;

     private GlobalData globalData;

     void Start () {
          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();

          if (globalData.coins_wait) {
               backButtonText.text = "Wait";

          }else {
               backButtonText.text = "Quit";
          }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick() {

          Debug.Log ("back click");
          rewardInfoSetup.StoreMotivationData(1);
          //Analytics.LogCritical ("Level Number", globalData.levelNumber + "");

          //store that back was clicked
          motivationJson = storeMotivationData.GetJsonString();

          Analytics.LogCritical ("JsonTest", motivationJson);
          Debug.Log (motivationJson);

          //playAnywayButton.GetComponent<Button>().interactable = false;

          if (globalData.coins_wait) {
               playAnywayButton.GetComponent<Button>().interactable = false;

          }else {
               
               quitPopup.SetActive (true);
          }
         
          //thankYouPopup.SetActive(true);
     }
}
