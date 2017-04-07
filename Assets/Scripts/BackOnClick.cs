using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackOnClick : MonoBehaviour {

	// Use this for initialization
	
     public GameObject thankYouPopup;
     public RewardsInfoPopupSetup rewardInfoSetup;

     void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick() {

          Debug.Log ("back click");
          //store that back was clicked
          rewardInfoSetup.StoreMotivationData(1);
          thankYouPopup.SetActive(true);
     }
}
