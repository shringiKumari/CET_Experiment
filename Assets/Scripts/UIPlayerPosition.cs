using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerPosition : MonoBehaviour {

     public GameObject player;
     public GameObject levelLength;

     private float previousPlayerPosition;
     private float initialPlayerPosition;
     private float progressBarLength; 



	// Use this for initialization
	void Start () {
          previousPlayerPosition = player.transform.position.x;
          initialPlayerPosition = 0f - player.transform.position.x;
          progressBarLength = levelLength.GetComponent<Image> ().sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
          if(player != null){
              
                    if (player.transform.position.x != previousPlayerPosition) {
                    //Vector3 tempPosition = new Vector3 ((0.01f/progressBarLength) * (player.transform.position.x + initialPlayerPosition), 0f); 
                    //float distance = player.transform.position.x - previousPlayerPosition; 
                    Vector3 tempPosition = new Vector3 ((progressBarLength/150), 0f); 
                    transform.position =  transform.position + tempPosition;
                    previousPlayerPosition = player.transform.position.x;
                    }
          }
		
	}
}
