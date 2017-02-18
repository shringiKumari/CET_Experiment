using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour {

     public Slider slider;
    

	// Use this for initialization
	void Start () {

		
	}

     void Awake () {
          slider.value = UnityEngine.Random.Range (0f, 1f);


     }
	// Update is called once per frame
	void Update () {
		
	}
}
