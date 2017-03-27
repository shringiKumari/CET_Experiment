using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_HUD : MonoBehaviour {

     private GlobalData globalData;
     public Text levelText; 
     private bool once = true;
     // Use this for initialization
	void Start () {

          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();

          if (once) {
               int levelNumber = globalData.levelNumber;
               levelText.text = "Level " + levelNumber;
               once = false;
          }


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void SetLevelHUDNumber (int levelNumber){

          levelText.text = "Level " + levelNumber;


     }

}
