using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//model of the data being stored in json.
[System.Serializable]
public struct Motivation {

     [System.Serializable]
     public struct MotivationModel {
          public int levelNumber;
          public bool coin_experiment;
          public bool coin_condition;
          public bool coin_wait;
          public string infoState;
          public float timeWaitedForCoins;
          public float totalCoinsEarned;

          public MotivationModel(int levelNumber, bool coin_experiment, bool coin_condition, bool coin_wait, string infoState, float timeWaitedForCoins, float totalCoinsEarned) {
               this.levelNumber = levelNumber;
               this.coin_experiment = coin_experiment;
               this.coin_condition = coin_condition;
               this.coin_wait = coin_wait;
               this.infoState = infoState;
               this.timeWaitedForCoins = timeWaitedForCoins;
               this.totalCoinsEarned = totalCoinsEarned;
          }
     }
     public List<MotivationModel> motivations;

     public void Add(MotivationModel model) {
          if (motivations == null) {
               motivations = new List<MotivationModel> ();
          }
               
          motivations.Add (model);
     }
}
