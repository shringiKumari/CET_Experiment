﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour {

     public GameObject player;
     public GameObject background;
     public GameObject envBG;
     private GameObject latestBG;
     private int levelCount = 0; 


     public float backgroundY = 0f;
     public float initialBGReference = -0.2f;

     private float backgroundLength;

	// Use this for initialization
	void Start () {
		
	}

     void Awake () {

          //initial platform positions
          Vector3 initialBackgroundPosition = new Vector3 (player.transform.position.x + initialBGReference, backgroundY); 
          background.transform.position = initialBackgroundPosition;
          backgroundLength = envBG.GetComponent<SpriteRenderer>().sprite.bounds.size.x;


          for (int i = 1; i <= 2; i++) {
               GameObject tempBG = GameObject.Instantiate (background); 
               tempBG.transform.position = initialBackgroundPosition + new Vector3 (i * backgroundLength, 0);
               latestBG = tempBG;
          }

     }

     public float GetBGLength() {
          return backgroundLength;
          }
	
	// Update is called once per frame
	void Update () {
          
          if ((levelCount < GlobalConstants.levelLength - 1) && (player != null)) {
               
               if (player.transform.position.x > latestBG.transform.position.x - (backgroundLength / 2)) {

                    GameObject tempBase = GameObject.Instantiate (background); 
                    tempBase.transform.position = latestBG.transform.position + new Vector3 (backgroundLength, 0);
                    latestBG = tempBase;
                    levelCount++;
               }
          }
		
	}
}
