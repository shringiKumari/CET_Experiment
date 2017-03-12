using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHUD : MonoBehaviour {

     public Text scoreText;
     public TimeHUD time;
     private GlobalData globalData;
     private int totalScore;
     public Coins_HUD coins;


     // Use this for initialization
	void Start () {
          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
          totalScore = globalData.levelTimeScore + globalData.levelHealthScore;
          scoreText.text = " Time Score " + globalData.levelTimeScore.ToString () + "\n" 
               + " Health Score " + globalData.levelHealthScore.ToString () + "\n"
               + " Total Score " + totalScore.ToString ();		
          int totalCoins = totalScore * 4;
          coins.setCoins(totalCoins + globalData.totalCoinsEarned);
          globalData.totalCoinsEarned += totalCoins;

	}
	
	// Update is called once per frame
	void Update () {

          //float timeScore = Mathf.FloorToInt((1000 - time.timeFromStart) * 5);// improve score formula

		
	}

     public int getScore() {
          return totalScore;
     }
}
