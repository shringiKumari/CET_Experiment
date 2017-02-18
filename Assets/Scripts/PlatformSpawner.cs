using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlatformGap
{
     private int platformLeft;
     private int platformRight;
     private float gapLeftX;
     private float gapRightX;

     public PlatformGap(int platformLeft, int platformRight, float gapLeftX, float gapRightX)
     {
          this.platformLeft = platformLeft;
          this.platformRight = platformRight;
          this.gapLeftX = gapLeftX;
          this.gapRightX = gapRightX;
     }
}

public class PlatformSpawner : MonoBehaviour {

     public GameObject platformLeft;
     public GameObject platformRight;
     public GameObject riverTop;
     public GameObject riverMid;
     public GameObject riverBase;
     public GameObject player;
     public GameObject wallSpawner;

     public float riverBaseY = 5f;
     private GameObject latestPlatformLeft;
     private GameObject latestRiverBase;
     private GameObject latestRiver;


     private float lastRightPlatformX;
     private float platformLength;
     private float riverTopLength;
     private float riverMidLength;
     private float riverBaseLength;

     public List<Transform> platformEndsList = new List<Transform> ();


     private int levelCount = 0; 
	// Use this for initialization


	void Start () {


		
	}

     void Awake () {
          
          //initial platform positions
          Vector3 initialPlatformPosition = new Vector3 (player.transform.position.x - 0.2f, GlobalConstants.riverHeight); 
          platformLeft.transform.position = initialPlatformPosition;
          platformLength = platformLeft.GetComponent<SpriteRenderer> ().sprite.bounds.size.x;
          platformRight.transform.position = initialPlatformPosition + new Vector3 (platformLength, 0);
         

          Vector3 firstPlatformLeftPosition = platformLeft.transform.position; 
           


          // river base
          Vector3 initialRiverBasePosition = new Vector3 (player.transform.position.x - 0.2f, GlobalConstants.riverHeight); 
          riverBase.transform.position = initialRiverBasePosition;
          riverBaseLength = riverBase.GetComponent<SpriteRenderer> ().sprite.bounds.size.x;

          //GenrateRiverBase (initialRiverBasePosition, 2);

          //initial river top and mid position
          Vector3 initialRiverPosition = new Vector3 (player.transform.position.x, riverBaseY); 
          riverTop.transform.position = initialRiverPosition;
          riverMid.transform.position = initialRiverPosition;
          riverTopLength = riverTop.GetComponentInChildren<SpriteRenderer> ().sprite.bounds.size.x;
          riverMidLength = riverMid.GetComponentInChildren<SpriteRenderer> ().sprite.bounds.size.x;

          //GenerateRiver (initialRiverPosition, 2);

          //if (levelCount < GlobalConstants.levelLength) {

          GeneratePlatform (firstPlatformLeftPosition, GlobalConstants.levelLength);
          GenrateRiverBase (initialRiverBasePosition, GlobalConstants.levelLength);
          GenerateRiver (initialRiverPosition, GlobalConstants.levelLength);

          //}
          wallSpawner.gameObject.SetActive (true);

     }

     void GeneratePlatform (Vector3 firstPlatformLeftPosition, int timesTorepeat)
     {
          for (int i = 1; i <= timesTorepeat; i++) {
               GameObject tempLeft = GameObject.Instantiate (platformLeft);
               platformEndsList.Add(tempLeft.transform.GetChild (0));
               tempLeft.transform.position = firstPlatformLeftPosition + new Vector3 (2 * i * platformLength, 0);
               GameObject tempRight = GameObject.Instantiate (platformRight);
               platformEndsList.Add(tempRight.transform.GetChild (0));
               float gapWidthRandom = UnityEngine.Random.Range(0f, 10f);
               tempRight.transform.position = firstPlatformLeftPosition + new Vector3 (2 * i * platformLength + platformLength + gapWidthRandom, 0);
               firstPlatformLeftPosition.x += gapWidthRandom;
               lastRightPlatformX = tempRight.transform.position.x;
               latestPlatformLeft = tempLeft;
          }
     }

     void GenrateRiverBase (Vector3 initialRiverBasePosition, int timesTorepeat)
     {
          for (int i = 1; i <= timesTorepeat; i++) {
               GameObject tempRiverBase = GameObject.Instantiate (riverBase);
               tempRiverBase.transform.position = initialRiverBasePosition + new Vector3 (i * riverBaseLength, 0);
               latestRiverBase = tempRiverBase;
          }
     }

     void GenerateRiver (Vector3 initialRiverPosition, int timesTorepeat)
     {
          for (int i = 1; i <= timesTorepeat; i++) {
               GameObject tempRiverTop = GameObject.Instantiate (riverTop);
               tempRiverTop.transform.position = initialRiverPosition + new Vector3 (i * riverTopLength, 0);
               GameObject tempRiverMid = GameObject.Instantiate (riverMid);
               tempRiverMid.transform.position = initialRiverPosition + new Vector3 (i * riverMidLength, 0);
               latestRiver = tempRiverMid;
          }
     }

     public float GetTotalLength() {
          return lastRightPlatformX;
     }

     public float GetCameraMax() {
          return lastRightPlatformX - platformLength;
     }

	// Update is called once per frame
	void Update () {
          /*
          if (levelCount < GlobalConstants.levelLength - 1) {
               if (player.transform.position.x > latestPlatformLeft.transform.position.x - (platformLength / 2)) {
                    GeneratePlatform (latestPlatformLeft.transform.position, 1);
                    
               }
               if (player.transform.position.x > latestRiverBase.transform.position.x - (riverBaseLength / 2)) {
                    GenrateRiverBase (latestRiverBase.transform.position, 1);
               }

               if (player.transform.position.x > latestRiver.transform.position.x - (riverMidLength / 2)) {

                    GenerateRiver (latestRiver.transform.position, 1);
                    levelCount++;
               }
          }
          */
		
	}
}
