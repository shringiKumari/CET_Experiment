using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonClick : MonoBehaviour {

	// Use this for initialization
     public GameObject notEnoughCoinsPopup;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick(){
          notEnoughCoinsPopup.SetActive (true);
     }
}
