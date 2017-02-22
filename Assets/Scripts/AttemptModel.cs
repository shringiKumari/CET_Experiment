using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Attempts {

     [System.Serializable]
     public struct AttemptModel {
          public bool  win;
          public float timeOfDeath;
          public float distanceTravelled;

          public AttemptModel(bool win, float timeOfDeath, float distanceTravelled) {
               this.win = win;
               this.timeOfDeath = timeOfDeath;
               this.distanceTravelled = distanceTravelled;
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
