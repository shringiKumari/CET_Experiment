﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins_HUD : MonoBehaviour {

     public Text coinsText;
     // Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

     public void setCoins(int coinsEarned){
          coinsText.text = "Total Coins " + coinsEarned.ToString ();
     }
}
