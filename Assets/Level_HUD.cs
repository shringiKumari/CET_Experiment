using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_HUD : MonoBehaviour {

     private GlobalData globalData;
     public Text levelText; 
     // Use this for initialization
	void Start () {

          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
          levelText.text = "Level " + globalData.levelNumber;

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
