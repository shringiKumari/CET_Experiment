using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayWithoutRewardsOnClick : MonoBehaviour {

	// Use this for initialization
     private GlobalData globalData;
     public Pauser pause;
     public GameObject noRewardsPopup;
     public GameObject levelStart;
     public GameObject backButton;


     void Start () {
          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
          if (backButton.activeSelf) {
               //Debug.Log("back button active");
               gameObject.transform.localPosition = new Vector2(70, -100);

          } else {
               //Debug.Log ("back button inactive");
               gameObject.transform.localPosition = new Vector2 (0, -100);
          }
		
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
