using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsDemandText : MonoBehaviour {

     private GlobalData globalData;
     public Text coinsDemandText;
     // Use this for initialization
	void Start () {
          globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalData>();
          coinsDemandText.text = globalData.totalCoinsNeeded.ToString () + "coins";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
