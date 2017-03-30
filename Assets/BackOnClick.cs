using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackOnClick : MonoBehaviour {

	// Use this for initialization
	
     public GameObject thankYouPopup;

     void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick() {

          Debug.Log ("back click");
          thankYouPopup.SetActive(true);
     }
}
