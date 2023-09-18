using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Med : MonoBehaviour
{
	public static bool iniciouJogo = false;
	private bool jogando;
	private bool acabouJogo;

	public float moveSpeed = 100f;
	public float moveSpeedControl = 12f;
	public float divingSpeed = 170f;
	public static int hp = 1;
	public int nivel = 2;
	private int lives;

	public GameObject prefab;
	public GameObject bolhaParticula;
	private Rigidbody2D body;
	private Animator anim;

	private Vector3 origem;
	private float size;

	public AudioClip[] audioDeath;
	public AudioClip[] audioPowerUp;
	public AudioClip audioDip;


	public GameObject finish;
	//public string nextScene = null;


	//Controle
	private bool controlTouch;
	private Vector2 touchBegan;
	private Vector2 touchEnded;
	private bool actionTouch;

	[Space(10)]
	[Header("Texto exibido no começo do game")]
	public Text txtStart;

	void Awake()
	{
		controlTouch = PlayerPrefs.GetInt ("control") == 0 ? false : false;
	}

	// Use this for initialization
	void Start ()
	{
		jogando = false;
		actionTouch = true;

		Debug.Log (PlayerPrefs.GetString("labCurrent") + " - " + PlayerPrefs.GetString("labNext"));

		GetComponent<Rigidbody2D>().isKinematic = true;

		body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		origem = gameObject.transform.position;
		size = gameObject.transform.localScale.x;

		moveSpeed = 100f;
		divingSpeed = 170f;
		moveSpeedControl = 12f;

		Player.hp = 2;
		body.gravityScale = -1f;
		Score.scoreLab = 10f;
	}

	void OnCollisionEnter2D(Collision2D colisor)
	{
		Debug.Log ("colisor .. " + colisor.gameObject.tag);

		if ((colisor.gameObject.tag == "Enemy" || colisor.gameObject.tag == "Obstacle") && !acabouJogo) {
			Player.hp -= 1;

			if (Player.hp <= 0) {
				lives = PlayerPrefs.GetInt ("lives") - 1;
				PlayerPrefs.SetInt ("lives", lives);

				Death ();
			}

			Debug.Log ("Hit . " + Player.hp.ToString ());
		}

		if (colisor.gameObject.tag == "ParticulaBolhas") {
			Debug.Log ("Colidiu com a bolha");
		}
	}

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag == "Finish" && !acabouJogo) {
			Score.GravaScore ();
			Finish.CarregaFinish ();
			finish.SetActive (true);
			Destroy (this.gameObject);

			//SceneManager.LoadScene(nextScene, LoadSceneMode.Single);

			//SceneManager.LoadScene(PlayerPrefs.GetString("labNext"), LoadSceneMode.Additive);
			//SceneManager.UnloadScene (PlayerPrefs.GetString("labCurrent"));
		}

		if (colisor.gameObject.tag == "ParticulaBolhas") {
			Debug.Log ("Colidiu com a bolha");
		}
	}

	void FixedUpdate()
	{
		// Startando o game
		if (Player.iniciouJogo) {
			Player.iniciouJogo = false;
			jogando = true;
			acabouJogo = false;
			GetComponent<Rigidbody2D> ().isKinematic = false;
			//gameEngine.SendMessage ("ComecouJogo");
		}


		// Reinicia o game para o tamanho ------------------------------------------
		if (transform.localScale.x < 0.20 && !acabouJogo) {
			Death ();
		}
	}


	// Update is called once per frame
	void Update ()
	{
		anim.SetBool ("Swim", false);

		// Controle para dispositivos mobile
		if (controlTouch && jogando && Input.touchCount == 1) {
			Touch toque = Input.touches [0];

			switch (toque.phase) {
			case TouchPhase.Began:
				actionTouch = true;
				touchBegan = toque.position;
				break;
			case TouchPhase.Ended:
				if (actionTouch) {
					actionTouch = false;
					touchEnded = toque.position;

					float difX = touchEnded.x - touchBegan.x;
					float difY = touchEnded.y - touchBegan.y;

					//txtStart.text = difX.ToString () + ", " + difY.ToString ();

					if (difX > 100f) {
						body.AddForce (new Vector2 (moveSpeed, 0f));
					} else if (difX < -100f) {
						body.AddForce (new Vector2 (moveSpeed * -1, 0f));
					} else if (difY > 200f) {
						// Ataque para Cima
					} else if (difY < -200f) {
						// Ataque para Baixo
					} else {
						anim.SetBool ("Swim", true);

						body.AddForce (new Vector2 (0f, divingSpeed));
						float sizeTemp = transform.localScale.x - 0.02f;
						GetComponent<AudioSource>().PlayOneShot(audioDip);
						gameObject.transform.localScale = new Vector3 (sizeTemp, sizeTemp, sizeTemp);
						GameObject particula = Instantiate (bolhaParticula);  
						particula.transform.position = gameObject.transform.position;

						// Modificando pontuação inicial
						Score.scoreLab -= 0.25f;
					}
				}

				break;
			case TouchPhase.Stationary:
				float timeTouch = toque.deltaTime;

				if (actionTouch && timeTouch > 0.050f) {
					actionTouch = false;

					body.AddForce (new Vector2 (0f, divingSpeed));
					float sizeTemp = transform.localScale.x - 0.02f;
					GetComponent<AudioSource>().PlayOneShot(audioDip);
					gameObject.transform.localScale = new Vector3 (sizeTemp, sizeTemp, sizeTemp);
					GameObject particula = Instantiate (bolhaParticula);  
					particula.transform.position = gameObject.transform.position;

					// Modificando pontuação inicial
					Score.scoreLab -= 0.25f;
				}
				break;
			}
		} else if (!controlTouch && jogando) {
			if (Input.GetButtonDown ("Jump")) {
				anim.SetBool ("Swim", true);

				body.AddForce (new Vector2 (0f, divingSpeed));
				float sizeTemp = transform.localScale.x - 0.02f;
				GetComponent<AudioSource> ().PlayOneShot (audioDip);
				gameObject.transform.localScale = new Vector3 (sizeTemp, sizeTemp, sizeTemp);
				GameObject particula = Instantiate (bolhaParticula);  
				particula.transform.position = gameObject.transform.position;

				// Modificando pontuação inicial
				Score.scoreLab -= 0.25f;
			}

			if (Input.GetButtonDown ("right")) {
				body.AddForce (new Vector2 (moveSpeedControl, 0f));
			} else if (Input.GetButtonDown ("left")) {
				body.AddForce (new Vector2 (moveSpeedControl * -1, 0f));
			}
		}

	}

	private void Death()
	{
		int i = Random.Range (0, audioDeath.Length);
		GetComponent<AudioSource> ().PlayOneShot (audioDeath [i]);

		anim.SetBool ("Died", true);
		acabouJogo = true;
		jogando = false;
	}

	public void FimAnimDeath()
	{
		if (lives > 0) {
			Player.hp = 2;
			Score.scoreLab = 10f;
			//iniciouJogo = false;
			LabirintoController.startGame = false;
			GetComponent<Rigidbody2D> ().isKinematic = true;
			anim.SetBool ("Died", false);
			anim.SetBool ("Continue", true);
			gameObject.transform.position = origem;
			gameObject.transform.localScale = new Vector3 (size, size, size);
			//Instantiate (prefab, origem, transform.localRotation);
			//Destroy (this.gameObject);
		} else {
			Destroy (this.gameObject);
			txtStart.fontSize = 80;
			txtStart.text = "Game Over";
		}
	}

	public void FimAnimContinue()
	{
		anim.SetBool ("Died", false);
		anim.SetBool ("Continue", true);

		//moveSpeed = 8.0f;
		//divingSpeed = -10.0f;
		//body.gravityScale = 1f;
	}

	public void Pause()
	{
		Debug.Log ("Pause");
	}
}
