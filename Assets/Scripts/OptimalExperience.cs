using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OptimalExperience : MonoBehaviour {

     public StoreAttempt store;

     // Make this a function of level length
     // Make this a behaviour tree

     private float totalDistanceToGoal = 198;
     private float minimumTime = 24;
     private float deltaCompetence = 0f;
     private int maxAttempts = 7;

     public float OptimizeExperience(){
          List<Attempts.AttemptModel> allAttempts = store.GetCurrentAttemptData ();
          int currentAttempt = 0;
          float timeToReachGoal = 0;
          float distanceTravelled = 0;
          float previousCompetence = 0;

          if (allAttempts != null) {
               currentAttempt = allAttempts.Count - 1;
               timeToReachGoal = allAttempts [currentAttempt].timeOfDeath;
               distanceTravelled = allAttempts [currentAttempt].distanceTravelled; 
               previousCompetence = allAttempts [currentAttempt].previousCompetenceValue;

                    
               if (currentAttempt < maxAttempts) {
                    if (allAttempts [currentAttempt].win) {
                         Debug.Log ("too easy");
                         //make more branches
                         if (timeToReachGoal <= minimumTime + 10) {
                              Debug.Log ("increase competence by " + (1 - (currentAttempt / maxAttempts)));
                              deltaCompetence = 0.4f * (1 - currentAttempt / maxAttempts);
                         } else {
                              Debug.Log ("increase competence by " + (1 - (currentAttempt / maxAttempts)));
                              deltaCompetence = 0.2f * (1 - currentAttempt / maxAttempts);
                         }

                    } else {
                         Debug.Log ("failed in first attempt : good");
                         if (distanceTravelled <= (0.6 + currentAttempt/20) * totalDistanceToGoal) {
                              Debug.Log ("decrease competence by " + (1 - (currentAttempt / maxAttempts)));
                              deltaCompetence = -0.2f * (1 - currentAttempt / maxAttempts); 
                         } else {
                              Debug.Log ("increase competence by" + (1 - (currentAttempt / maxAttempts)));
                              deltaCompetence = 0.1f * (1 - currentAttempt / maxAttempts);
                         }
                   
                    }
                    return Mathf.Clamp(previousCompetence + deltaCompetence, 0.1f, 0.9f);

               } else {
                    float tempCompetence = 0f;
                    for (int i = 0; i <= currentAttempt; i++) {
                         if (allAttempts [i].distanceTravelled >= 0.7 * totalDistanceToGoal) {
                              if(tempCompetence < allAttempts [i].previousCompetenceValue){
                                   tempCompetence = allAttempts [i].previousCompetenceValue;
                              }
                         }
                         if (tempCompetence > 0) {
                              return UnityEngine.Random.Range (tempCompetence + 0.05f, tempCompetence - 0.05f);
                         } else {
                              return UnityEngine.Random.Range (previousCompetence + 0.05f, previousCompetence - 0.05f);
                         }

                    }
               }


          }
          //set initial slider value
          return UnityEngine.Random.Range (0.1f, 0.9f);
          }

     }
