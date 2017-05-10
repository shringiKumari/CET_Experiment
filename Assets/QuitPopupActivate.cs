using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPopupActivate : MonoBehaviour {

     public GameObject quitPopup;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick() {
          quitPopup.SetActive (true);
     }
}
