using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberText : MonoBehaviour {

     public Text levelText;
     private GlobalData globalData;


     // Use this for initialization
	void Start () {

          //globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();

		
	}

     public void SetLevelNumber (int levelNumber) {

          levelText.text = " LEVEL " + levelNumber.ToString();
          
     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
