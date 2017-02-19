using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float spawnTime = 0.5f;		// The amount of time between each spawn.
	public float spawnDelay = 0.3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.
     public GameObject player;
     public NoiseGenerator noise;


	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .

	}


	void Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
          if (player != null) {
               Vector2 tempPosition = new Vector2 (player.transform.position.x, transform.position.y);
               Instantiate (enemies [enemyIndex], tempPosition, transform.rotation);
          }

		// Play the spawning effect from all of the particle systems.
		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}
	}

     public void GenerateNewEnemies (float noise, float competenceValue) {
          
          //float tempNoise = noise.GetNoise(); 
          float tempNoise = UnityEngine.Random.Range(1f, 1f) * (1/competenceValue);
          CancelInvoke("Spawn");
          InvokeRepeating("Spawn", tempNoise * spawnDelay, tempNoise * spawnTime);
          Debug.Log (" Spawn Delay " + spawnDelay * tempNoise);
          
     }
     public void OnClickApply(float noise, float competenceValue) {


          GenerateNewEnemies (noise, competenceValue);
          
          
          
     }
}
