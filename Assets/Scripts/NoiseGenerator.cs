using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// generates noise for all PCG elements
public class NoiseGenerator : MonoBehaviour {
	
     [SerializeField] private AnimationCurve noiseCurve;

     public float GetNoise()
     {
          return noiseCurve.Evaluate (Random.value);
     }
          
}
