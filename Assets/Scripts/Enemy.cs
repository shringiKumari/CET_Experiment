using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public float moveSpeed = 2f;		
	public int HP = 2;					
	public Sprite deadEnemy;			
	public Sprite damagedEnemy;			
	public AudioClip[] deathClips;		
	public GameObject hundredPointsUI;	
	public float deathSpinMin = -100f;			
	public float deathSpinMax = 100f;			


	private SpriteRenderer ren;			
	private Transform frontCheck;		 
	private bool dead = false;			


	
	void Awake()
	{
		// Setting up the references.
		ren = transform.Find("body").GetComponent<SpriteRenderer>();
		frontCheck = transform.Find("frontCheck").transform;
		
	}

	void FixedUpdate ()
	{
		// Create an array of all the colliders in front of the enemy.
		Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position, 1);

		// Check each of the colliders.
		foreach(Collider2D c in frontHits)
		{
               if((c.tag == "Obstacle") || (c.gameObject.tag == "Player"))
			{
				// ... Flip the enemy and stop checking the other colliders.
                    //Debug.Log("flip flip flip");
                    Flip ();
				break;
			}
		}

		
		GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);	

		
		if(HP == 1 && damagedEnemy != null)
			
			ren.sprite = damagedEnemy;
			
		
		if(HP <= 0 && !dead)
			
			Death ();
	}
	

	
     public void Hurt()
	{
		// Reduce the number of hit points by one.
		HP--;
	}
	
	void Death()
	{
		// Find all of the sprite renderers on this object and it's children.
		SpriteRenderer[] otherRenderers = GetComponentsInChildren<SpriteRenderer>();

		// Disable all of them sprite renderers.
		foreach(SpriteRenderer s in otherRenderers)
		{
			s.enabled = false;
		}

		// Re-enable the main sprite renderer and set it's sprite to the deadEnemy sprite.
		ren.enabled = true;
		ren.sprite = deadEnemy;


		// Set dead to true.
		dead = true;

		// Allow the enemy to rotate and spin it by adding a torque.
		GetComponent<Rigidbody2D>().AddTorque(Random.Range(deathSpinMin,deathSpinMax));

		// Find all of the colliders on the gameobject and set them all to be triggers.
		Collider2D[] cols = GetComponents<Collider2D>();
		foreach(Collider2D c in cols)
		{
			c.isTrigger = true;
		}

		// Play a random audioclip from the deathClips array.
		int i = Random.Range(0, deathClips.Length);
		AudioSource.PlayClipAtPoint(deathClips[i], transform.position);

          Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
          for (int colliderCount = 0; colliderCount < colliders.Length; colliderCount++) 
          {
               colliders [colliderCount].isTrigger = true;
          }
	}


	public void Flip()
	{
		// Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
}
