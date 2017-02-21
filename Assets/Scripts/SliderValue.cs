using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour {

     public Slider slider;
     public PlatformSpawner platformSpawner;
     public WallSpawner wallspawner;
     public Spawner enemySpawner;

     private float previousSliderValue = -1f;

     public NoiseGenerator platformNoise;
     public NoiseGenerator wallNoise;
     public NoiseGenerator enemyNoise;

     /*public enum competenceLevel{
          LOW,
          MEDIUM,
          HIGH
     }

     public competenceLevel competence; */ 
    
     public int c;

    // Use this for initialization
	void Start () {
          OnClickApply ();
	}

     void Awake () {
          slider.value = UnityEngine.Random.Range (0.1f, 0.9f);
          if (slider.value <= 0.25) {
               //competence = competenceLevel.LOW;
               c = 0;
          } else if (slider.value <= 0.65) {
               //competence = competenceLevel.MEDIUM;
               c = 1;
          } else {
               //competence = competenceLevel.HIGH;
               c = 2;
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
               
               platformSpawner.OnClickApply (GetPlatformNoise(), slider.value);
               wallspawner.OnClickApply (GetWallNoise(), slider.value);
               enemySpawner.OnClickApply (GetEnemyNoise(), slider.value);

               previousSliderValue = slider.value;
          }
     }

     // Update is called once per frame
	void Update () {
		
	}
}
