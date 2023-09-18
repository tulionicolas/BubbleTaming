using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerUps : MonoBehaviour
{


	public static bool concha = false;
	public static bool alga = false;

	public GameObject spriteConcha;
	public GameObject spriteAlga;

	private float timeAlga;

	void Awake()
	{
		timeAlga = 0;
	}

	// Use this for initialization
	void Start ()
	{
		//concha.SetActive (false);
		//alga.SetActive (false);

		//qtdConcha = PlayerPrefs.GetInt ("PowerUpConcha");
		//qtdAlga = PlayerPrefs.GetInt ("PowerUpAlga");

		//txbConcha.text = qtdConcha.ToString();
		//txbAlga.text = qtdAlga.ToString();
	}

	void Update()
	{
		if (PowerUps.concha) {
			spriteConcha.SetActive (true);
			PowerUps.concha = false;
		}

		if (PowerUps.alga) {
			timeAlga = 30f;
			spriteAlga.SetActive (true);
			PowerUps.alga = false;
		}

		if (timeAlga >= 0)
			timeAlga -= 1f * Time.deltaTime;

        if (timeAlga <= 0 || Bubble.hp <= 0)
			spriteAlga.SetActive (false);
		
        if (Bubble.hp <= 1) {
            spriteConcha.SetActive(false);
        }
			
	}
}
