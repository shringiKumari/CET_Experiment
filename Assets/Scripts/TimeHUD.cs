using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeHUD : MonoBehaviour {

     public Text timeText;
     public float timeFromStart;
     private int timeInMin;
     private float timeInSec;
     private string timeGap;

     // Use this for initialization
	void Start () {
		
          timeFromStart = 0;
	}
	
	// Update is called once per frame
	void Update () {
          timeFromStart += Time.deltaTime;
          timeInMin = Mathf.FloorToInt(timeFromStart / 60);
          timeInSec = Mathf.FloorToInt(timeFromStart % 60);

          if (timeInSec < 10) {
               timeGap = "0";
          } else {
               timeGap = "";
          }

          timeText.text = " Time " + timeInMin.ToString() + ":" + timeGap + timeInSec.ToString();

          Debug.Log (Time.deltaTime);

		
	}
}
