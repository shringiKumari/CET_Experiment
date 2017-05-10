using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuitPopupYes : MonoBehaviour {
     [SerializeField] private Pauser pauser;
     private string quitScreenInfo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick() {

          if (Time.timeScale == 1) {
               quitScreenInfo = "ingame";
          } else {
               quitScreenInfo = "level screen";
          }
          pauser.Pause (false);

          Analytics.LogCritical ("Quit", quitScreenInfo);
          Debug.Log ("Quit");
          Debug.Log (quitScreenInfo);

          SceneManager.LoadScene("Questions_End", LoadSceneMode.Single);

          //Debug.Log ("Application Quit");
          //Application.Quit ();
     }
}
