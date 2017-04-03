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
     private float startCompetence = 0.26f;
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

               Attempts.AttemptModel currentModel = allAttempts[currentAttempt];
               if(currentModel.win){
                    return previousCompetence + 0.15f;
               }
               else{
                   return previousCompetence;
               }
          }
          //set initial slider value
        return startCompetence;
        }

     }
