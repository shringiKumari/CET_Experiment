using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class StoreAttempt : MonoBehaviour {

     public void OnAttempt(float timeToReachGoal, float timeOfDeath, int deathOnPlatform) {
          Attempts.AttemptModel attempt = new Attempts.AttemptModel (timeToReachGoal, timeOfDeath, deathOnPlatform);

          FileStream stream = new FileStream (Application.persistentDataPath + "/attempts.json", FileMode.OpenOrCreate);
          StreamReader reader = new StreamReader (stream);
          string json = reader.ReadToEnd ();
          Debug.Log (json.Length);
          stream.Close ();
          stream = new FileStream (Application.persistentDataPath + "/attempts.json", FileMode.Truncate);

          Attempts attempts = new Attempts ();
          if (!string.IsNullOrEmpty (json)) {
               attempts = JsonUtility.FromJson<Attempts> (json);
          }

          attempts.Add (attempt);
          json = JsonUtility.ToJson(attempts);
          StreamWriter writer = new StreamWriter (stream);
          writer.Write (json);
          writer.Flush ();
          stream.Close ();
     }
}
