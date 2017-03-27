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

     public void SetLevelNumber (int levelNumber, int maxLevel) {

          if (levelNumber < maxLevel) {
               levelText.text = " LEVEL " + levelNumber.ToString () + " complete ";
          } else {
               levelText.text = " GAME COMPLETE ";
          }
          
     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
