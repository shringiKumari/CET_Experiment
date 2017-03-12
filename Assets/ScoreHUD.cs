using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHUD : MonoBehaviour {

     public Text scoreText;
     public TimeHUD time;


     // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

          float timeScore = Mathf.FloorToInt((1000 - time.timeFromStart) * 5);// improve score formula
          scoreText.text = " Score " + timeScore.ToString ();
		
	}
}
