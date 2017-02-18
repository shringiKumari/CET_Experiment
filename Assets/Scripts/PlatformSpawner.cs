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
     public float riverBaseY = 5f;
     private GameObject latestPlatformLeft;
     private GameObject latestRiverBase;
     private GameObject latestRiver;

     private float platformLength;
     private float riverTopLength;
     private float riverMidLength;
     private float riverBaseLength;


     private int levelCount = 0; 
	// Use this for initialization


	void Start () {


		
	}

     void Awake () {
          
          //initial platform positions
          Vector3 initialPlatformPosition = new Vector3 (player.transform.position.x - 0.2f, GlobalConstants.bankHeight); 
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

          // river base
          Vector3 initialRiverBasePosition = new Vector3 (player.transform.position.x - 0.2f, GlobalConstants.bankHeight); 
          riverBase.transform.position = initialRiverBasePosition;
          riverBaseLength = riverBase.GetComponent<SpriteRenderer> ().sprite.bounds.size.x;

          for (int i = 1; i <= 2; i++) {
               GameObject tempRiverBase = GameObject.Instantiate (riverBase); 
               tempRiverBase.transform.position = initialRiverBasePosition + new Vector3 (i * riverBaseLength, 0);
               latestRiverBase = tempRiverBase;
          }
          //initial river top and mid position
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
               latestRiver = tempRiverMid;
          }




     }
	
	// Update is called once per frame
	void Update () {

          if (levelCount < GlobalConstants.levelLength) {
               if (player.transform.position.x > latestPlatformLeft.transform.position.x - (platformLength / 2)) {

                    GameObject tempLeft = GameObject.Instantiate (platformLeft); 
                    tempLeft.transform.position = latestPlatformLeft.transform.position + new Vector3 (2 * platformLength, 0);
                    GameObject tempRight = GameObject.Instantiate (platformRight); 
                    tempRight.transform.position = latestPlatformLeft.transform.position + new Vector3 (3 * platformLength, 0);

                    latestPlatformLeft = tempLeft;
               
                    
               }
               if (player.transform.position.x > latestRiverBase.transform.position.x - (riverBaseLength / 2)) {

                    GameObject tempBase = GameObject.Instantiate (riverBase); 
                    tempBase.transform.position = latestRiverBase.transform.position + new Vector3 (riverBaseLength, 0);
                    latestRiverBase = tempBase;
               }

               if (player.transform.position.x > latestRiver.transform.position.x - (riverMidLength / 2)) {

                    GameObject tempRiverTop = GameObject.Instantiate (riverTop); 
                    tempRiverTop.transform.position = latestRiver.transform.position + new Vector3 (riverTopLength, 0);
                    GameObject tempRiverMid = GameObject.Instantiate (riverMid); 
                    tempRiverMid.transform.position = latestRiver.transform.position + new Vector3 (riverMidLength, 0);
                    latestRiver = tempRiverMid;
                    levelCount++;
               }
          }
		
	}
}
