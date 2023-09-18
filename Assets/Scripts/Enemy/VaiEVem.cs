using UnityEngine;
using System.Collections;

public class VaiEVem : MonoBehaviour {

	public float moveSpeed = 2.0f;		// The speed the enemy moves at.
	public int force = 1;
	public int hp = 2;

	[Space(10)]
	[Header("Direção inicial do peixe")]
	public bool right = true;

	private SpriteRenderer sprite;			// Reference to the sprite renderer.
	private Transform frontCheck;		// Reference to the position of the gameobject used for checking if something is in front.

	private Rigidbody2D body;

	private bool obstacle = false;
	private bool obstacleEnemy = false;

	// Use this for initialization
	void Awake ()
	{
		body = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		frontCheck = transform.Find("FrontCheck").transform;

		moveSpeed = Random.Range (1.5f, 5f);

		moveSpeed *= (right ? 1 : -1);
	}

	void OnCollisionEnter2D(Collision2D colisor)
	{
		if (colisor.gameObject.tag == "Player") {
			Flip ();
		}
	}

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag == "ObstacleEnemy" || colisor.gameObject.tag == "Enemy") {
			Flip ();
		}
	}

	void FixedUpdate ()
	{

		//body.AddForce(new Vector2(moveSpeed, 0f));
		body.velocity = new Vector2 (moveSpeed, 0f);

		obstacle = Physics2D.Linecast (transform.position, frontCheck.position, 1 << LayerMask.NameToLayer ("Obstacle"));

		if(obstacle)
		{
			// ... Flip the enemy and stop checking the other colliders.
			Flip ();
		}
	}

	public void Flip()
	{
		moveSpeed *= -1;

		Vector2 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
}
