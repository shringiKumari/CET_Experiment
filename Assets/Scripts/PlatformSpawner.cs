using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

     public GameObject platformLeft;
     public GameObject platformRight;
     public GameObject riverTop;
     public GameObject riverMid;
     public GameObject riverBase;
     public GameObject player;
     //private float platformX;
     public float platformY = -9.6f;
     //private float RiverX;
     public float riverY = -9.6f;
     public float riverBaseY = 5f;
     private GameObject latestPlatformLeft;
     private float platformLength;
     private float riverTopLength;
     private float riverMidLength;
     private float riverBaseLength;
	// Use this for initialization


	void Start () {


		
	}

     void Awake () {
          
          //initial platform positions
          Vector3 initialPlatformPosition = new Vector3 (player.transform.position.x - 0.2f, platformY); 
          platformLeft.transform.position = initialPlatformPosition;
          platformLength = platformLeft.GetComponent<SpriteRenderer> ().sprite.bounds.size.x;
          platformRight.transform.position = initialPlatformPosition + new Vector3 (platformLength, 0);
         

          Vector3 firstPlatformLeftPosition = platformLeft.transform.position; 
           

          for (int i = 1; i <= 2; i++) {
               GameObject tempLeft = GameObject.Instantiate (platformLeft); 
               tempLeft.transform.position = firstPlatformLeftPosition + new Vector3 (2 * i * platformLength, 0);
               GameObject tempRight = GameObject.Instantiate (platformRight); 
               tempRight.transform.position = firstPlatformLeftPosition + new Vector3 (2 * i * platformLength + platformLength, 0);
               latestPlatformLeft = tempLeft;
          }

          Vector3 initialRiverBasePosition = new Vector3 (player.transform.position.x - 0.2f, riverY); 
          riverBase.transform.position = initialRiverBasePosition;
          riverBaseLength = riverBase.GetComponent<SpriteRenderer> ().sprite.bounds.size.x;

          for (int i = 1; i <= 2; i++) {
               GameObject tempRiverBase = GameObject.Instantiate (riverBase); 
               tempRiverBase.transform.position = initialRiverBasePosition + new Vector3 (i * riverBaseLength, 0);
               //latestPlatformLeft = tempLeft;
          }
          //initial river position
          Vector3 initialRiverPosition = new Vector3 (player.transform.position.x, riverBaseY); 
          riverTop.transform.position = initialRiverPosition;
          riverMid.transform.position = initialRiverPosition;
          riverTopLength = riverTop.GetComponentInChildren<SpriteRenderer> ().sprite.bounds.size.x;
          riverMidLength = riverMid.GetComponentInChildren<SpriteRenderer> ().sprite.bounds.size.x;

          for (int i = 1; i <= 2; i++) {
               GameObject tempRiverTop = GameObject.Instantiate (riverTop); 
               tempRiverTop.transform.position = initialRiverPosition + new Vector3 (i * riverTopLength, 0);
               GameObject tempRiverMid = GameObject.Instantiate (riverMid); 
               tempRiverMid.transform.position = initialRiverPosition + new Vector3 (i * riverMidLength, 0);
               //latestPlatformLeft = tempLeft;
          }




     }
	
	// Update is called once per frame
	void Update () {

          if (player.transform.position.x > latestPlatformLeft.transform.position.x - (platformLength / 2)) {

               GameObject tempLeft = GameObject.Instantiate (platformLeft); 
               tempLeft.transform.position = latestPlatformLeft.transform.position + new Vector3 (2 * platformLength, 0);
               GameObject tempRight = GameObject.Instantiate (platformRight); 
               tempRight.transform.position = latestPlatformLeft.transform.position + new Vector3 (3 * platformLength, 0);

               latestPlatformLeft = tempLeft;
               
                    
          }


		
	}
}
