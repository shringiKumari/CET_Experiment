using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeText : MonoBehaviour {

     private GlobalData globalData;
     public Text upgradeText;
	// Use this for initialization
	void Start () {
          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
          if(globalData.totalCoinsEarned < globalData.totalCoinsNeeded){
               upgradeText.text = "You do not have enough coins.";
          } else {
               upgradeText.text = "Sorry, Upgrade is not available.";
          }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
