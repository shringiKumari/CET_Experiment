using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndTracker : MonoBehaviour {

	// Use this for initialization
     public Remover remover;
     public PlayerDistance playerDistance;
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

     private void GameEnd(bool win) {
          // all deaths should come via killTrigger(Remover)


          //how many times has the game ended so far

          //record time from start to death
          endTime = Time.time - startTime;
          Debug.Log (" End Time " + endTime);
          Debug.Log ("Game has ended"); 

          //record platform of death or distance travelled before death
          float tempDistance = playerDistance.DistanceTravelled ();
          Debug.Log (" Distance Travelled " + tempDistance);
          storeAttempt.OnAttempt (win, endTime, tempDistance);


     }
}
