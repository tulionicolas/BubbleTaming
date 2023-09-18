using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Vida : MonoBehaviour {
	public Text txbVida;
	private int qtdVida;

	void Awake()
	{
		//PlayerPrefs.SetInt ("lives", 10);
		qtdVida = PlayerPrefs.GetInt ("lives");
		txbVida.text = qtdVida.ToString();
	}

	void FixedUpdate()
	{
		qtdVida = PlayerPrefs.GetInt ("lives");
		txbVida.text = qtdVida.ToString();
	}
}
