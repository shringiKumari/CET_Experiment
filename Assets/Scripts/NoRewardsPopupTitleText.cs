using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoRewardsPopupTitleText : MonoBehaviour {

     private GlobalData globalData;
     public Text noRewardsTitleText;

     // Use this for initialization
	
     void Start () {
          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
          noRewardsTitleText.text = "LEVEL" + globalData.levelNumber.ToString ();


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
