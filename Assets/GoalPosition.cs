using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPosition : MonoBehaviour {

     public BackgroundSpawner backgroundSpawner;
     // Use this for initialization
	void Start () {
          Vector2 tempPosition = new Vector2((GlobalConstants.levelLength) * backgroundSpawner.GetBGLength (), GlobalConstants.bankHeight);
          transform.position = tempPosition;		
	}

     void Awake () {


     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
