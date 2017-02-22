using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attempts {

     [System.Serializable]
     public class AttemptModel {
          public float timeToReachGoal;
          public float timeOfDeath;
          public int deathOnPlatform; 
     }
     public AttemptModel[] attempts;
}
