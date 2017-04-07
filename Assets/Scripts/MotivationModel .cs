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
          public string infoState;
          public float timeWaitedForCoins;

          public MotivationModel(int levelNumber, bool coin_experiment, bool coin_condition, string infoState, float timeWaitedForCoins) {
               this.levelNumber = levelNumber;
               this.coin_experiment = coin_experiment;
               this.coin_condition = coin_condition;
               this.infoState = infoState;
               this.timeWaitedForCoins = timeWaitedForCoins;
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
