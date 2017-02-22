using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fitness : MonoBehaviour {

     public PlatformSpawner platformSpawner;
     public WallSpawner wallSpawner;
     public Spawner enemySpawner; 

     // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public bool FitnessCheck( competenceLevel competence) {

          float d = platformSpawner.totalGapWidth + wallSpawner.totalBrickHeight - enemySpawner.spawnNoise;
          //Debug.Log ("difficulty" + d);
          //Debug.Log ("competence level" + competence);
          switch (competence) {
          case competenceLevel.LOW:
               if (d < 0)
                    return true;
               break;
          case competenceLevel.MEDIUM:
               if (d > 0 && d <= 50) // makes these magic values a function of comptence
                    return true;
               break;
          case competenceLevel.HIGH:
               if (d > 50)
                    return true;
               break;               
          }
          return false;
     }
}
