using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour
{
	public GameObject[] trashItem;
	public int itens;
	public int itemTemp;
	public bool trap;

	public float time = 2f;

	// Use this for initialization
	void Start ()
	{
		trap = false;
		itens = trashItem.Length;
		itemTemp = 0;
	}

	void FixedUpdate()
	{

	}

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag == "Player") {
			trap = true;

			if (itens != 0) {
				Invoke ("LiberaTrash", time);
			}
		}
	}

	private void LiberaTrash()
	{
		Rigidbody2D rbItem = trashItem [itemTemp].GetComponent<Rigidbody2D>();
		Collider2D c2dItem = trashItem [itemTemp].GetComponent<Collider2D> ();

		rbItem.isKinematic = false;

		if (itemTemp < itens) {
			itemTemp++;
		}
	}


}
