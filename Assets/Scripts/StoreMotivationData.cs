﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;

//data read and write
public class StoreMotivationData : MonoBehaviour {

     public static string dataFileName = "motivation.json";

     public void OnProgress(int levelNumber, bool coin_experiment, bool coin_condition, string infoState, float timeWaitedForCoins) {
          Motivation.MotivationModel motivation = new Motivation.MotivationModel(levelNumber, coin_experiment, coin_condition, infoState, timeWaitedForCoins);

          FileStream stream = new FileStream (Application.persistentDataPath + "/" + dataFileName, FileMode.OpenOrCreate);
          StreamReader reader = new StreamReader (stream);
          string json = reader.ReadToEnd ();
          stream.Close ();
          reader.Close();
          stream = new FileStream (Application.persistentDataPath + "/" + dataFileName, FileMode.Truncate);

          Motivation motivations = new Motivation ();
          if (!string.IsNullOrEmpty (json)) {
               motivations = JsonUtility.FromJson<Motivation> (json);
          }

          motivations.Add (motivation);
          json = JsonUtility.ToJson(motivations);
          StreamWriter writer = new StreamWriter (stream);
          writer.Write (json);
          writer.Flush ();
          stream.Close ();
     }

     public List<Motivation.MotivationModel> GetCurrentMotivationData(){
          if (File.Exists (Application.persistentDataPath + "/" + dataFileName)) {
               FileStream stream = new FileStream (Application.persistentDataPath + "/" + dataFileName, FileMode.Open);
               StreamReader reader = new StreamReader (stream);
               string json = reader.ReadToEnd ();

               if (!string.IsNullOrEmpty (json)) {
                    Motivation motivations = JsonUtility.FromJson<Motivation> (json);
                    stream.Close ();
                    reader.Close ();
                    return motivations.motivations;
               }
            stream.Close ();
            reader.Close ();
          }
          return null;
     }



     private void OnApplicationQuit(){
          //FileStream stream = new FileStream (Application.persistentDataPath + "/" + dataFileName, FileMode.Truncate);
          //stream.Close ();
     }
}