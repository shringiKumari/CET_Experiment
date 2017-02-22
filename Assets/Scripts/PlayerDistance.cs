using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistance : MonoBehaviour {


	// Use this for initialization	
     void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public float DistanceTravelled() {
          return transform.position.x;
     }
}
