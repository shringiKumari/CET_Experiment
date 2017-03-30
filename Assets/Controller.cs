using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	// Use this for initialization
     public GameObject levelStart;
     public GameObject noRewardsPopup;


     void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void ManageCoinPopups() {
          noRewardsPopup.SetActive (true);
          levelStart.SetActive (false);
     }
}
