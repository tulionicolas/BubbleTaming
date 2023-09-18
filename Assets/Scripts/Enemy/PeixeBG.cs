using UnityEngine;
using System.Collections;

public class PeixeBG : MonoBehaviour
{
	private Rigidbody2D body;

	public int move;
	public int moveMin = 1;
	public int moveMax = 4;

	public float scaleX = 0.5f;
	public float scaleY = 0.5f;
	public float scaleMin = 0.4f;
	public float scaleMax = 0.7f;

	public Vector3 posInicial;


	private void CarregaPeixe()
	{
		//Instantiate (espinhaPrefab, posInicial, transform.localRotation);
		//Destroy (this.gameObject);
		scaleX = Random.Range (scaleMin, scaleMax);
		scaleY = Random.Range (scaleMin, scaleMax);
		gameObject.transform.localScale = new Vector3(scaleX, scaleY);

		move = Random.Range (moveMin, moveMax);
		transform.position = posInicial;
	}

	// Use this for initialization
	void Awake ()
	{
		body = GetComponent<Rigidbody2D> ();

		scaleX = Random.Range (scaleMin, scaleMax);
		scaleY = Random.Range (scaleMin, scaleMax);
		gameObject.transform.localScale = new Vector3(scaleX, scaleY);


		move = Random.Range (moveMin, moveMax);
		posInicial = transform.position;
	}

	void OnBecameInvisible()
	{
		Invoke ("CarregaPeixe", 3f);
	}


	void FixedUpdate ()
	{
		body.velocity = new Vector2 (move, 0f);
	}
}
