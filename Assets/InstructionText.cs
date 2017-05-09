using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionText : MonoBehaviour {

     public Text instructionText;

     private GlobalData globalData;

     // Use this for initialization
	void Start () {

          /*globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
          if (globalData.coins_condition) {
               instructionText.text = "abcdefgh";
          } else {
               instructionText.text = "abcd";
          }
          */

          instructionText.text = 
               "You will play a basic 2D platformer game and fill a questionnaire about your experience. \n\n" +
               "The game has fixed number of levels. Cross the red flag to complete the level.\n\n" +
               "Controls\nLeft Arrow/ ‘A’ - to go left.\nRight Arrow/ ‘D’ - to go right.\nUp Arrow/ Spacebar - to jump.\n\n";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
