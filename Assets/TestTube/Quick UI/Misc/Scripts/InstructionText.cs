﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionText : MonoBehaviour {

     public Text instructionText;

     private GlobalData globalData;

     // Use this for initialization
	void Start () {

          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();

          //instructionText.text = "blaaaa";
       

          if (globalData.coins_condition) {
               instructionText.text = 
                    "Play a level based 2D platformer game and fill a questionnaire about your experience. \n\n" +
                    "Earn COINS to UPGRADE hero as the games gets harder every level.\n\n" +
                    "Controls\nLeft Arrow/ ‘A’ - to go left.\nRight Arrow/ ‘D’ - to go right.\nUp Arrow/ Spacebar - to jump.\n\n";
          } else {
               instructionText.text = 
                    "Play a level based 2D platformer game and fill a questionnaire about your experience. \n\n" +
                    "Controls\nLeft Arrow/ ‘A’ - to go left.\nRight Arrow/ ‘D’ - to go right.\nUp Arrow/ Spacebar - to jump.\n\n";
          }




          
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
