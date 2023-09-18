using UnityEngine;
using System.Collections;

public class Trash : MonoBehaviour
{	
	private Rigidbody2D body;
	private int atrito;
	public int atritoMinimo = 1;
	public int atritoMaximo = 5;

	private float xAtual;
	public float xInicial;
	public float xFinal;

	private Vector3 posInicial;
	private Vector3 pos;

	public GameObject[] trashItem;
	public int itens;
	public GameObject item;

	// Use this for initialization
	void Awake ()
	{
		//body = GetComponent<Rigidbody2D> ();

		itens = trashItem.Length;
		item = trashItem[Random.Range (0, itens)];


		//atrito = Random.Range (atritoMinimo, atritoMaximo);
		//body.drag = atrito;

		posInicial = transform.position;

		xAtual = Random.Range (xInicial, xFinal);
		pos = new Vector3 (xAtual, posInicial.y);

		Instantiate (item, pos, transform.rotation);
	}

	void FixedUpdate()
	{


	}

	void OnBecameInvisible()
	{
		Destroy (item);

		item = trashItem[Random.Range (0, itens)];

		xAtual = Random.Range (xInicial, xFinal);
		pos = new Vector3 (xAtual, posInicial.y);

		//atrito = Random.Range (atritoMinimo, atritoMaximo);
		Instantiate (item, pos, transform.rotation);

		//body.drag = atrito;
	}
}
