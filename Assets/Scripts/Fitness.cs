using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TO DO : make the magic values a function of comptence .
// Instead of declaring numbers here pick it from SliderValue monobehaviour

public class Fitness : MonoBehaviour {

     public PlatformSpawner platformSpawner;
     public WallSpawner wallSpawner;
     public Spawner enemySpawner; 

     private float lowDifficulty = 0f; // lowest competenc scale * 10
     private float mediumDifficulty = 50f; // mid level competence scale * 10
     // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public bool FitnessCheck( competenceLevel competence) {

          float d = platformSpawner.totalGapWidth + wallSpawner.totalBrickHeight - enemySpawner.spawnNoise;// tried with math varoations of these. Looks like simple works best.
          //Debug.Log ("difficulty" + d);
          //Debug.Log ("competence level" + competence);
          switch (competence) {
          case competenceLevel.LOW:
               if (d < lowDifficulty)
                    return true;
               break;
          case competenceLevel.MEDIUM:
               if (d > lowDifficulty && d <= mediumDifficulty) // TO DO : make these magic values a function of comptence
                    return true;
               break;
          case competenceLevel.HIGH:
               if (d > mediumDifficulty)
                    return true;
               break;               
          }
          return false;
     }
}
