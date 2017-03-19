using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// used for data collection when player dies
public class Remover : MonoBehaviour
{
	public GameObject splash;
     public GameEndEvent gameEndEvent = new GameEndEvent();


	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{
			// .. stop the camera tracking the player
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;

			// .. stop the Health Bar following the player
			if(GameObject.FindGameObjectWithTag("HealthBar").activeSelf)
			{
				GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
			}

			// ... instantiate the splash where the player falls in.
			Instantiate(splash, col.transform.position, transform.rotation);
			// ... destroy the player.
			Destroy (col.gameObject);
			// ... reload the level.
               //gameEndEvent.Invoke();
               StartCoroutine(ReloadGame(false));
		}
		else
		{
			// ... instantiate the splash where the enemy falls in.
			Instantiate(splash, col.transform.position, transform.rotation);

			// Destroy the enemy.
			Destroy (col.gameObject);	
		}
	}

     public IEnumerator ReloadGame(bool win)
	{			
          gameEndEvent.Invoke(win);
          // ... pause briefly
          yield return new WaitForSeconds(0.5f);
          // ... and then reload the level.
          SceneManager.LoadScene("Level", LoadSceneMode.Single);
	}

     public void updateKillTrigger(float killTriggerSize)
     {
          BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D> ();
          boxCollider2D.size = new Vector2 (killTriggerSize, boxCollider2D.size.y);
     }
}
