using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//checks for collision when player jumps on enemy
public class EnemyTopCollision : MonoBehaviour {

     public Enemy enemy;
     //public PlayerHealth playerHealth;


	// Use this for initialization
	void Start () {
		
	}
	
     void OnCollisionEnter2D (Collision2D collision2D) {

          if (collision2D.gameObject.tag == "Player") {
               enemy.Hurt ();
               //playerHealth.NotHurt ();
          }
     }
	

     // Update is called once per frame
	void Update () {
		
	}
}
