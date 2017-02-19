using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour {

	
     [SerializeField] private AnimationCurve noiseCurve;

     public float GetNoise()
     {
          return noiseCurve.Evaluate (Random.value);
     }
}
