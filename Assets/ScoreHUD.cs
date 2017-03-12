using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHUD : MonoBehaviour {

     public Text scoreText;
     public TimeHUD time;
     private GlobalData globalData;


     // Use this for initialization
	void Start () {
          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
		
	}
	
	// Update is called once per frame
	void Update () {

          //float timeScore = Mathf.FloorToInt((1000 - time.timeFromStart) * 5);// improve score formula
          int totalScore = globalData.levelTimeScore + globalData.levelHealthScore;
          scoreText.text = " Time Score " + globalData.levelTimeScore.ToString () + "\n" 
                         + " Health Score " + globalData.levelHealthScore.ToString () + "\n"
                         + " Total Score " + totalScore.ToString ();
		
	}
}
