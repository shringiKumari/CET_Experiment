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
          scoreText.text = "  Time Score  " + globalData.levelTimeScore.ToString () + "\n" 
               + " Health Score " + globalData.levelHealthScore.ToString () + "\n"
               + "-------------------" + "\n"
               + "  Total Score " + totalScore.ToString ();		
          //scoreText.text = "Your Score" + totalScore.ToString ();
          int totalCoins = totalScore * 2;
          coins.setCoins(totalCoins + globalData.totalCoinsEarned);
          globalData.totalCoinsEarned += totalCoins;
          if (globalData.coins_experiment) {
               if ((globalData.coins_condition) && (globalData.levelNumber < globalData.firstNoRewardLevel)) {
                    gameObject.transform.localPosition = new Vector2 (0, 60);
               } else {
                    gameObject.transform.localPosition = new Vector2 (0, -75);
               }
          } else {
               gameObject.transform.localPosition = new Vector2 (0, -20);
          }

	}
	
	// Update is called once per frame
	void Update () {

          //float timeScore = Mathf.FloorToInt((1000 - time.timeFromStart) * 5);// improve score formula

		
	}

     public int getScore() {
          return totalScore;
     }
}
