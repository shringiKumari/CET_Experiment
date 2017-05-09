using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ThankYouOnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick() {
     

          SceneManager.LoadScene("Questions_End", LoadSceneMode.Single);

          //Debug.Log ("Application Quit");
          //Application.Quit ();
     }


}
