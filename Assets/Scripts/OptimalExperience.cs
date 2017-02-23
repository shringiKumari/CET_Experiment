using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OptimalExperience : MonoBehaviour {

     public StoreAttempt store;

     // Make this a behaviour tree

     private float totalDistanceToGoal = 198; //TO DO: read this value from goal position
     private float minimumTime = 24; // TO DO: read as totalDistance/ Player speed. 
     private float deltaCompetence = 0f;
     private int maxAttempts = 7; // caliberation limit for playtests else run it for higher numbers and see what happens.
     private float timeBuffer = 10f;

     private float competenceStep = 0.2f;
     private float minCompetence = 0.1f;
     private float maxCompetence = 0.9f;
     private float respectableDistanceFactor = 0.7f; // 70% there! Just 30% of the distance away from goal. It increases with each attempt by a factor of 1/20;
    

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
                         if (timeToReachGoal <= minimumTime + timeBuffer) {
                              Debug.Log ("increase competence by " + (1 - (currentAttempt / maxAttempts)));
                              deltaCompetence = (2f * competenceStep) * (1 - currentAttempt / maxAttempts);
                         } else {
                              Debug.Log ("increase competence by " + (1 - (currentAttempt / maxAttempts)));
                              deltaCompetence = competenceStep * (1 - currentAttempt / maxAttempts);
                         }

                    } else {
                         Debug.Log ("failed in this attempt : good");
                         if (distanceTravelled <= (respectableDistanceFactor + currentAttempt/20) * totalDistanceToGoal) {
                              Debug.Log ("decrease competence by " + (1 - (currentAttempt / maxAttempts)));
                              deltaCompetence =  (-1f * competenceStep) * (1 - currentAttempt / maxAttempts); 
                         } else {
                              Debug.Log ("increase competence by" + (1 - (currentAttempt / maxAttempts)));
                              deltaCompetence = (0.5f * competenceStep) * (1 - currentAttempt / maxAttempts);
                         }
                   
                    }
                    return Mathf.Clamp(previousCompetence + deltaCompetence, minCompetence, maxCompetence);

               } else {
                    float tempCompetence = 0f;
                    for (int i = 0; i <= maxAttempts; i++) {
                         if (allAttempts [i].distanceTravelled >= respectableDistanceFactor * totalDistanceToGoal) {
                              if(tempCompetence < allAttempts [i].previousCompetenceValue){
                                   tempCompetence = allAttempts [i].previousCompetenceValue;
                              }
                         }
                         if (tempCompetence > 0) {
                              return UnityEngine.Random.Range (tempCompetence + 0.05f, tempCompetence - 0.02f);
                         } else {
                              return UnityEngine.Random.Range (previousCompetence + 0.05f, previousCompetence - 0.02f);
                         }

                    }
               }


          }
          //set initial slider value
          return UnityEngine.Random.Range (minCompetence, maxCompetence);
          }

     }
