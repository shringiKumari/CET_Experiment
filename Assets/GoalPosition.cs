using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPosition : MonoBehaviour {

     public PlatformSpawner platformSpawner;
     public GameObject player;
     // Use this for initialization
	void Start () {
          Vector2 tempPosition = new Vector2(platformSpawner.GetTotalLength(), GlobalConstants.bankHeight);
               
          transform.position = tempPosition;		
	}

     void Awake () {


     }
	
	// Update is called once per frame
	void Update () {

          if (player.transform.position.x >= transform.position.x) {

               Debug.Log ("Game Win");
          }
		
	}
}
