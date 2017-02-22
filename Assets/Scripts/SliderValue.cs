using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum competenceLevel{
     LOW,
     MEDIUM,
     HIGH
}

public class SliderValue : MonoBehaviour {

     public Slider slider;
     public PlatformSpawner platformSpawner;
     public WallSpawner wallspawner;
     public Spawner enemySpawner;

     private float previousSliderValue = -1f;

     public NoiseGenerator platformNoise;
     public NoiseGenerator wallNoise;
     public NoiseGenerator enemyNoise;
     public OptimalExperience optimalExperience;

     public Fitness fitness;

     public competenceLevel competence;  

     public enum competenceChange
     {
          SYSTEM_CHANGE,
          PLAYER_CHANGE
     }
    
     private int fitnessCheckCounter = 0;

     // Use this for initialization
     void Start () {
          GenerateLevel ();
     }

     void Awake () {
          // do it only once in game start 
          //slider.value = UnityEngine.Random.Range (0.1f, 0.9f);
          slider.value = optimalExperience.OptimizeExperience(); 
          Debug.Log (" competence " + slider.value);

     }

     private void UpdateCompetenceLevel ()
     {
          if (slider.value <= 0.25) {
          competence = competenceLevel.LOW;
          }
          else if (slider.value <= 0.65) {
               competence = competenceLevel.MEDIUM;
          }
          else {
               competence = competenceLevel.HIGH;
          }
     }
     
     public float GetPlatformNoise() {
          if (platformNoise.enabled) {
               return platformNoise.GetNoise ();
          } else
               return 0;
     }

     public float GetWallNoise() {
          if (wallNoise.enabled) {
               return wallNoise.GetNoise ();
          } else
               return 0;

     }

     public float GetEnemyNoise() {
          if (enemyNoise.enabled) {
               return enemyNoise.GetNoise ();
          } else
               return 0;
          
     }

     public void OnClickApply () {
          
          Debug.Log ("competence value" + slider.value);
          if (slider.value != previousSliderValue) {
               GenerateLevel ();
               previousSliderValue = slider.value;
          }
     }

     public void GenerateLevel () {
          UpdateCompetenceLevel ();
          platformSpawner.OnClickApply (GetPlatformNoise(), slider.value);
          wallspawner.OnClickApply (GetWallNoise(), slider.value);
          enemySpawner.OnClickApply (GetEnemyNoise(), slider.value);

          if (!fitness.FitnessCheck (competence)) {
               fitnessCheckCounter++;
               if (fitnessCheckCounter > 5) {
                    Debug.Log ("Cannot find level with proper fitness");
                    slider.value = slider.value + UnityEngine.Random.Range (-0.1f, 0.1f);
                    fitnessCheckCounter = 0;
               }
               GenerateLevel ();
          }
          fitnessCheckCounter = 0;
     }


     // Update is called once per frame
	void Update () {
		
	}
}
