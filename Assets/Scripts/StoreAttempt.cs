using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;

//data read and write
public class StoreAttempt : MonoBehaviour {

     public static string dataFileName = "attempts.json";

     public void OnAttempt(bool win, float timeOfDeath, float distanceTravelled, float previousCompetenceValue) {
          Attempts.AttemptModel attempt = new Attempts.AttemptModel (win, timeOfDeath, distanceTravelled, previousCompetenceValue);

          FileStream stream = new FileStream (Application.persistentDataPath + "/" + dataFileName, FileMode.OpenOrCreate);
          StreamReader reader = new StreamReader (stream);
          string json = reader.ReadToEnd ();
          stream.Close ();
          reader.Close();
          stream = new FileStream (Application.persistentDataPath + "/" + dataFileName, FileMode.Truncate);

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

     public List<Attempts.AttemptModel> GetCurrentAttemptData(){
          if (File.Exists (Application.persistentDataPath + "/" + dataFileName)) {
               FileStream stream = new FileStream (Application.persistentDataPath + "/" + dataFileName, FileMode.Open);
               StreamReader reader = new StreamReader (stream);
               string json = reader.ReadToEnd ();

               if (!string.IsNullOrEmpty (json)) {
                    Attempts attempts = JsonUtility.FromJson<Attempts> (json);
                    stream.Close ();
                    reader.Close ();
                    return attempts.attempts;
               }
            stream.Close ();
            reader.Close ();
          }
          return null;
     }



     private void OnApplicationQuit(){
          FileStream stream = new FileStream (Application.persistentDataPath + "/" + dataFileName, FileMode.Truncate);
          stream.Close ();
     }
}
