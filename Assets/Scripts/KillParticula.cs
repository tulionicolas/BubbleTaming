﻿using UnityEngine;
using System.Collections;

public class KillParticula : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Invoke ("MataParticula", 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void MataParticula()
	{
		Destroy (gameObject);
	}
}
