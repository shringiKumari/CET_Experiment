using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Attempts {

     [System.Serializable]
     public struct AttemptModel {
          public float timeToReachGoal;
          public float timeOfDeath;
          public int deathOnPlatform;

          public AttemptModel(float timeToReachGoal, float timeOfDeath, int deathOnPlatform) {
               this.timeToReachGoal = timeToReachGoal;
               this.timeOfDeath = timeOfDeath;
               this.deathOnPlatform = deathOnPlatform;
          }
     }
     public List<AttemptModel> attempts;

     public void Add(AttemptModel model) {
          if (attempts == null) {
               attempts = new List<AttemptModel> ();
          }
               
          attempts.Add (model);
     }
}
