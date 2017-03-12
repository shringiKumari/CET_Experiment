using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour {

     public int levelNumber = 1;
     public int levelTimeScore;
     public int levelHealthScore;
     // Use this for initialization
	void Start () {
		
	}

     void Awake () {
          DontDestroyOnLoad (gameObject);

     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
