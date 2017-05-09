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

          instructionText.text = "abcdefgh";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
