using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float spawnTime = 0.5f;		// The amount of time between each spawn.
	public float spawnDelay = 0.3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.
     public GameObject player;

     private float competence;

     public float spawnNoise;

	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .

	}


     void Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
          if (player != null) {
               Vector2 tempPosition = new Vector2 (player.transform.position.x + ((1 - competence)* 5), transform.position.y);
               Debug.Log ("spawn position" + tempPosition.x);
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
          //float tempNoise = UnityEngine.Random.Range(1f, 1f) * (1/competenceValue);
          //float tempNoise = UnityEngine.Random.Range(20f, 20f) * (1 - competenceValue);
          //Debug.Log("Perlin" + Mathf.PerlinNoise(Time.time, 0));
          //Debug.Log("Perlin Delay" + (1 - competenceValue) * Mathf.PerlinNoise(Time.time, 0));

          competence = competenceValue;
          spawnNoise = noise * 2 * Mathf.Sqrt(2) * (1 - competenceValue);
          CancelInvoke("Spawn");
          //InvokeRepeating("Spawn", tempNoise * spawnDelay, tempNoise * spawnTime);
          InvokeRepeating("Spawn", spawnNoise, spawnNoise);
          Debug.Log (" Spawn Delay " + spawnNoise);
          
     }
     public void OnClickApply(float noise, float competenceValue) {


          GenerateNewEnemies (noise, competenceValue);
          
          
          
     }
}
