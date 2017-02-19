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
    

    // Use this for initialization
	void Start () {
          OnClickApply ();
	}

     void Awake () {
          slider.value = UnityEngine.Random.Range (0f, 1f);
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
