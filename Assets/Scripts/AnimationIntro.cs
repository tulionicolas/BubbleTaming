using UnityEngine;
using System.Collections;

public class AnimationIntro : MonoBehaviour
{
	public GameObject Mundo01;
	public GameObject Mundo02;
	public GameObject Mundo03;
	public GameObject Mundo04;
	public GameObject Mundo05;
	public GameObject Mundo06;

	// Use this for initialization
	void Awake () {

		if (PlayerPrefs.GetInt ("m06") == 1) {
			Mundo06.SetActive (true);
		} else if (PlayerPrefs.GetInt ("m05") == 1) {
			Mundo05.SetActive (true);
		} else if (PlayerPrefs.GetInt ("m04") == 1) {
			Mundo04.SetActive (true);
		} else if (PlayerPrefs.GetInt ("m03") == 1) {
			Mundo03.SetActive (true);
		} else if (PlayerPrefs.GetInt ("m02") == 1) {
			Mundo02.SetActive (true);
		} else {
			Mundo01.SetActive (true);
		}
	}
}
