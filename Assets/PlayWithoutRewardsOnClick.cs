using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWithoutRewardsOnClick : MonoBehaviour {

	// Use this for initialization
     public Pauser pause;
     public GameObject noRewardsPopup;
     public GameObject levelStart;


     void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick() {
          pause.Pause (false);
          levelStart.SetActive (false);
          noRewardsPopup.SetActive (false);

     }
}
