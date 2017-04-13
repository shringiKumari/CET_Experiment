using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackOnClick : MonoBehaviour {

	// Use this for initialization
	
     public GameObject thankYouPopup;
     public RewardsInfoPopupSetup rewardInfoSetup;
     public Transform playAnywayButton;

     void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick() {

          //Debug.Log ("back click");
          //store that back was clicked
          rewardInfoSetup.StoreMotivationData(1);
          playAnywayButton.GetComponent<Button>().interactable = false;
         
          //thankYouPopup.SetActive(true);
     }
}
