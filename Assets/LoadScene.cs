using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadScene : MonoBehaviour {

	[SerializeField] private GameObject levelStart;
     public Pauser pause;

     public StoreAttempt store;
	// Use this for initialization
	void Start () {


          List<Attempts.AttemptModel> allAttempts = store.GetCurrentAttemptData ();
          if (allAttempts != null) {
               int currentAttempt = allAttempts.Count - 1;
               bool gameWin = allAttempts [currentAttempt].win;
               if (gameWin) {
                    levelStart.SetActive (true);
                    pause.Pause (true);
               } else {
                    levelStart.SetActive (false);
               }
          } else {
               pause.Pause (true);
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
