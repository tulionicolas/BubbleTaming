using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LabirintoController : MonoBehaviour
{
    public string nameLevel;
	public string current;
	public string next;

	[Space(10)]
	[Header("Texto exibido no começo do game")]
	public Text txtStart;
    public Text txtLevel;

	public static bool startGame;
	public static bool playing;
	public static bool finishGame;

	private float startTime;


	Vector2 touchInicio = Vector2.zero;
	Vector2 touchFim = Vector2.zero;

	[Space(10)]
	[Header("Controle")]
	public GameObject joystickBtn01;
	public GameObject joystickBtn02;


	void Awake()
	{
		LabirintoController.startGame = false;
		LabirintoController.playing = false;
		LabirintoController.finishGame = false;
		startTime = 0;

		PlayerPrefs.SetString ("labCurrent", current);
		PlayerPrefs.SetString ("labNext", next);

        txtLevel.text = nameLevel;
		txtStart.text = Language.tapStart != null ? Language.tapStart : "GO";
	}

	void FixedUpdate()
	{
		//if (startTime != 0) {
			
			// Para despositivos moveis
			if (Input.touchCount > 0 && !LabirintoController.startGame) {
				Touch toque = Input.touches [0];

				switch (toque.phase) {
    				case TouchPhase.Ended:
    					LabirintoController.startGame = true;

                        txtLevel.text = "";

    					txtStart.text = "";
    					txtStart.fontSize = 300;
                        Bubble.iniciouJogo = true;
                        LabirintoController.playing = true;
    					break;
				}
			}


			// Para Computadores e joysticks
			if (Input.GetButtonDown ("Fire1")) {
				if (!LabirintoController.startGame) {
					LabirintoController.startGame = true;

                    txtLevel.text = "";

					txtStart.text = "";
					txtStart.fontSize = 300;
                    Bubble.iniciouJogo = true;
                    LabirintoController.playing = true;
				}
			}

            /*
			if (LabirintoController.startGame && startTime > 0.5f) {
				startTime -= 0.05f;
				txtStart.text = startTime.ToString ("0");
			}

			if (startTime <= 0.55f) {
				startTime = 0;
				txtStart.text = "";
				Debug.Log ("Iniciou a GAME");
				Bubble.iniciouJogo = true;
                LabirintoController.playing = true;

			}
		} else */
        if (!LabirintoController.startGame) {
			txtStart.fontSize = 150;
			txtStart.text = Language.tapStart != null ? Language.tapStart : "GO";
            txtLevel.text = nameLevel;
			startTime = 3.50f;
		}
	}

}
