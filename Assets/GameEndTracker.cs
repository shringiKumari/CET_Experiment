using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndTracker : MonoBehaviour {

	// Use this for initialization
     public Remover remover;
     public StoreAttempt storeAttempt;

     public float startTime;
     public float endTime;


     void Awake () {
          startTime = Time.time;
          Debug.Log (" Start Time " + startTime);
     }

     void Start () {
          remover.gameEndEvent.AddListener (GameEnd);
     }	
	// Update is called once per frame
	void Update () {
		
	}

     private void GameEnd() {
          // all deaths should come via killTrigger(Remover)

          //record platform of death
          //how many times has the game ended so far

          //record time from start to death
          endTime = Time.time - startTime;
          Debug.Log (" End Time " + endTime);
          Debug.Log ("Game has ended"); 
          storeAttempt.OnAttempt (0, endTime, 2);


     }
}
