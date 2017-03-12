using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadScene : MonoBehaviour {

	[SerializeField] private GameObject levelStart;
	[SerializeField] private GameObject enemySpawner;
	[SerializeField] private GameObject gameUI;

     public StoreAttempt store;
	// Use this for initialization
	void Start () {

          List<Attempts.AttemptModel> allAttempts = store.GetCurrentAttemptData ();
          if (allAttempts != null) {
               int currentAttempt = allAttempts.Count - 1;
               bool gameWin = allAttempts [currentAttempt].win;
               if (gameWin) {
                    levelStart.SetActive (true);
               } else {
                    levelStart.SetActive (false);
                    gameUI.SetActive(true);
                    enemySpawner.SetActive(true);
               }
          }


	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick () {
            gameUI.SetActive(true);
		  enemySpawner.SetActive(true);
		  levelStart.SetActive(false);

     }
}
