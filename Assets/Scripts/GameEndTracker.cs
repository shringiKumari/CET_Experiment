using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndTracker : MonoBehaviour {

	// Use this for initialization
     public Remover remover;
     public PlayerDistance playerDistance;
     public StoreAttempt storeAttempt;
     public Slider previousCompetenceValue;
     public PlayerHealth playerHealth;
     private GlobalData globalData;

     private float startTime;
     private float endTime;



     void Awake () {
          startTime = Time.time;
          //Debug.Log (" Start Time " + startTime);
     }

     void Start () {

          globalData = GameObject.FindGameObjectWithTag ("GlobalData").GetComponent<GlobalData> ();
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
          //Debug.Log (" End Time " + endTime);
          //Debug.Log ("Game has ended"); 

          //record platform of death or distance travelled before death
          float tempDistance = playerDistance.DistanceTravelled ();
          //Debug.Log (" Distance Travelled " + tempDistance);
          storeAttempt.OnAttempt (win, endTime, tempDistance, previousCompetenceValue.value);

          globalData.levelTimeScore = Mathf.FloorToInt(100 - endTime);
          globalData.levelHealthScore = Mathf.FloorToInt (playerHealth.health);


     }

     private void OnDestroy(){
          remover.gameEndEvent.RemoveListener (GameEnd);
     }


}
