using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseGenerator : MonoBehaviour {

     public Slider competenceSlider;
	
     [SerializeField] private AnimationCurve noiseCurve;

     public float GetNoise()
     {
          return competenceSlider.value * noiseCurve.Evaluate (Random.value);
     }
          
}
