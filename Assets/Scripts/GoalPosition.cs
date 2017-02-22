using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPosition : MonoBehaviour {

     public PlatformSpawner platformSpawner;
     public GameObject player;
     public Pauser pauser;
     private bool gameWon = false;
     // Use this for initialization
	void Start () {
          Vector2 tempPosition = new Vector2(platformSpawner.GetTotalLength(), GlobalConstants.bankHeight);
               
          transform.position = tempPosition;		
	}

     void Awake () {


     }
	
	// Update is called once per frame
     public void updateGoalPosition( float goalPositionX) {

          Vector2 tempPosition = new Vector2(goalPositionX, GlobalConstants.bankHeight);

          transform.position = tempPosition;

          
     }

     void Update () {

          if (player != null) {
               if (player.transform.position.x >= transform.position.x) {
                    Debug.Log ("Game Win");
                    if (!gameWon) {
                         
                         StartCoroutine (ReloadGame());
                         gameWon = true;
                    }
               }
          }
		
	}

     IEnumerator ReloadGame()
     {
          // ... pause briefly
          yield return new WaitForSeconds(0.7f);
          // ... and then reload the level.
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
     }
}
