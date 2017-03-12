﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadScene : MonoBehaviour {

	[SerializeField] private GameObject levelStart;
     public Pauser pause;
     public LevelNumberText levelNumberText;
     private GlobalData globalData;

     public StoreAttempt store;
	// Use this for initialization
	void Start () {

          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
          List<Attempts.AttemptModel> allAttempts = store.GetCurrentAttemptData ();
          if (allAttempts != null) {
               int currentAttempt = allAttempts.Count - 1;
               bool gameWin = allAttempts [currentAttempt].win;
               if (gameWin) {
                    levelNumberText.SetLevelNumber (++globalData.levelNumber);
                    levelStart.SetActive (true);
                    pause.Pause (true);
               } else {
                    levelStart.SetActive (false);
               }
          } else {
               pause.Pause (true);
               levelNumberText.SetLevelNumber (globalData.levelNumber);

          }


	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick () {

            pause.Pause (false);
		  levelStart.SetActive(false);

     }
}