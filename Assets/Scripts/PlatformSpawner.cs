using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlatformSpawner : MonoBehaviour {

     public GameObject platformLeft;
     public GameObject platformRight;
     public GameObject riverTop;
     public GameObject riverMid;
     public GameObject riverBase;
     public GameObject player;
     public GameObject wallSpawner;
     public Remover remover;

     public GoalPosition goalPosition;
    

     public float riverBaseY = 5f;

     private GameObject latestPlatformLeft;
     private GameObject latestRiverBase;
     private GameObject latestRiver;
     private float lastProcessedCompetenceValue;
     private List<GameObject> platformList = new List<GameObject> ();



     private float lastRightPlatformX;
     private float platformLength;
     private float riverTopLength;
     private float riverMidLength;
     private float riverBaseLength;

     public List<Transform> platformEndsList = new List<Transform> ();
     [SerializeField] public NoiseGenerator noiseGenerator;

     public float totalGapWidth = 0f;
 
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



          //initial river top and mid position
          Vector3 initialRiverPosition = new Vector3 (player.transform.position.x, riverBaseY); 
          riverTop.transform.position = initialRiverPosition;
          riverMid.transform.position = initialRiverPosition;
          riverTopLength = riverTop.GetComponentInChildren<SpriteRenderer> ().sprite.bounds.size.x;
          riverMidLength = riverMid.GetComponentInChildren<SpriteRenderer> ().sprite.bounds.size.x;


          //GeneratePlatform (firstPlatformLeftPosition, GlobalConstants.levelLength);
          GenrateRiverBase (initialRiverBasePosition, GlobalConstants.levelLength);
          GenerateRiver (initialRiverPosition, GlobalConstants.levelLength);


          wallSpawner.gameObject.SetActive (true);

     }

     void GeneratePlatform (Vector3 firstPlatformLeftPosition, int timesTorepeat, float noise, float competenceValue)
     {
          totalGapWidth = 0;
          for (int i = 1; i <= timesTorepeat; i++) {
               GameObject tempLeft = GameObject.Instantiate (platformLeft);
               platformList.Add (tempLeft);
               platformEndsList.Add(tempLeft.transform.GetChild (0));
               tempLeft.transform.position = firstPlatformLeftPosition + new Vector3 (2 * i * platformLength, 0);
               GameObject tempRight = GameObject.Instantiate (platformRight);
               platformList.Add (tempRight);
               platformEndsList.Add(tempRight.transform.GetChild (0));
               float gapWidthRandom = noise * 10f * competenceValue;
               //Debug.Log ("random noise" + gapWidthRandom);
               //float gapWidthRandom = UnityEngine.Random.Range(0f, 10f) * competenceValue;
               tempRight.transform.position = firstPlatformLeftPosition + new Vector3 (2 * i * platformLength + platformLength + gapWidthRandom, 0);
               firstPlatformLeftPosition.x += gapWidthRandom;
               lastRightPlatformX = tempRight.transform.position.x;
               latestPlatformLeft = tempLeft;
               totalGapWidth = totalGapWidth + gapWidthRandom;
          }
          Debug.Log (totalGapWidth + "totalGapWidth");
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
         

     public void OnClickApply(float noise, float competenceValue) {
          int w = 0;
          while(w < platformList.Count){

               GameObject W = platformList [w];
               Destroy (platformList [w]);
               w++;

          }
          platformList.Clear ();
          platformEndsList.Clear ();

          GeneratePlatform (platformLeft.transform.position , GlobalConstants.levelLength, noise, competenceValue);
          lastRightPlatformX = platformList [platformList.Count - 1].transform.position.x;


          goalPosition.updateGoalPosition (lastRightPlatformX);
          remover.updateKillTrigger (lastRightPlatformX);

     }
	// Update is called once per frame
	void Update () {
		
	}
}
