using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnoughCoinsOkButtonClick : MonoBehaviour {


     public GameObject notEnoughCoinsPopup;
     // Use this for initialization
	void Start () {
          
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick() {
          notEnoughCoinsPopup.SetActive (false);
     }
}
