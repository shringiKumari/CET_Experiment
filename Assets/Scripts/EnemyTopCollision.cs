using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTopCollision : MonoBehaviour {

     public Enemy enemy;


	// Use this for initialization
	void Start () {
		
	}
	
     void OnCollisionEnter2D (Collision2D collision2D) {

          if (collision2D.gameObject.tag == "Player") {
               enemy.Hurt ();
          }


     }
	
     // Update is called once per frame
	void Update () {
		
	}
}
