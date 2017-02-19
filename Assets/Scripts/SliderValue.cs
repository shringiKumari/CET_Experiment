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

    //public NoiseGenerator noise;

    // Use this for initialization
	void Start () {
          OnClickApply ();
	}

     void Awake () {
          slider.value = UnityEngine.Random.Range (0f, 1f);
     }
	
     public void OnClickApply () {
          if (slider.value != previousSliderValue) {
               
               platformSpawner.OnClickApply (slider.value);
               wallspawner.OnClickApply ();
               enemySpawner.OnClickApply ();

               previousSliderValue = slider.value;
          }
     }

     // Update is called once per frame
	void Update () {
		
	}
}
