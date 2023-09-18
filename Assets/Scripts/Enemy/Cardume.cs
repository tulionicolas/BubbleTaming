using UnityEngine;
using System.Collections;

public class Cardume : MonoBehaviour
{
	public float moveSpeed = 2.0f;		// The speed the enemy moves at.
	public int force = 1;
	public int hp = 2;

	private SpriteRenderer sprite;			// Reference to the sprite renderer.
	private Transform frontCheck;		// Reference to the position of the gameobject used for checking if something is in front.

	private Rigidbody2D body;

	// Use this for initialization
	void Awake ()
	{
		body = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		frontCheck = transform.Find("FrontCheck").transform;
	}

	void OnCollisionEnter2D(Collision2D colisor)
	{
		//Debug.Log ("Objeto encostou em " + colisor.gameObject.layer);
		if (colisor.gameObject.tag == "Obstacle" || colisor.gameObject.tag == "Player") {
			moveSpeed *= -1;
			Flip ();
		}
	}

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag == "ObstacleEnemy") {
			moveSpeed *= -1;
			Flip ();
		}
	}

	void FixedUpdate ()
	{
		body.velocity = new Vector2 (moveSpeed, 0f);
	}

	public void Flip()
	{
		Vector2 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
}
