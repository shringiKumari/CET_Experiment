using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuitPopupYes : MonoBehaviour {
     [SerializeField] private Pauser pauser;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick() {

          pauser.Pause (false);
          SceneManager.LoadScene("Questions_End", LoadSceneMode.Single);

          //Debug.Log ("Application Quit");
          //Application.Quit ();
     }
}
