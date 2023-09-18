using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Bubble : MonoBehaviour
{
	public static bool iniciouJogo = false;
	private bool acabouJogo;
    private bool slowMotion = false;

	public float moveSpeed = 100f;
	public float divingSpeed = -170f;
	public static int hp = 1;
	public int nivel = 2;
	private int lives;
	private int moveUP;

	public GameObject prefab;
	public GameObject bolhaParticula;
	private Rigidbody2D body;
	private Animator anim;

	private Vector3 origem;
	public static float size;

	public AudioClip[] audioDeath;
	public AudioClip[] audioPowerUp;
	public AudioClip audioDip;

	//Colisores para animacao
	private Transform colisorTop;
	private Transform colisorBottom;
	private Transform colisorLeft;
	private Transform colisorRight;

	private bool animTop = false;
	private bool animBottom = false;
	private bool animLeft = false;
	private bool animRight = false;

	public GameObject finish;

	//Controle
	private Vector2 touchBegan;
    private Vector2 touchDirection;
	private Vector2 touchEnded;
	private bool actionTouch;

	[Space(10)]
	[Header("Texto exibido no começo do game")]
	public Text txtStart;

	void Awake()
	{
		moveUP = (PlayerPrefs.GetInt ("move") < 0 ? 0 : PlayerPrefs.GetInt ("move"));

		colisorTop = transform.Find ("colisorTop");
		colisorBottom = transform.Find ("colisorBottom");
		colisorLeft = transform.Find ("colisorLeft");
		colisorRight = transform.Find ("colisorRight");
	}

	// Use this for initialization
	void Start ()
	{
        Time.timeScale = 1f;

		actionTouch = true;
        slowMotion = false;

		Debug.Log (PlayerPrefs.GetString("labCurrent") + " - " + PlayerPrefs.GetString("labNext"));

		GetComponent<Rigidbody2D>().isKinematic = true;

		body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		origem = gameObject.transform.position;
		size = gameObject.transform.localScale.x;

        moveSpeed = 150f; //<<< apenas mobile (12f para outros)
        divingSpeed = -170f; //<<< apenas mobile (-180f para outros)

		Bubble.hp = 1;
		body.gravityScale = 1.5f;
		Score.scoreLab = 10f;
	}

	void OnCollisionEnter2D(Collision2D colisor)
	{
		Debug.Log ("Colidiu com a bolha");


		if ((colisor.gameObject.tag == "Enemy" || colisor.gameObject.tag == "Obstacle") && !acabouJogo) {
			Bubble.hp -= 1;

			if (Bubble.hp <= 0) {
                //LabirintoController.playing = false;
				//lives = PlayerPrefs.GetInt ("lives") - 1;
				//PlayerPrefs.SetInt ("lives", lives);
				Death ();
			}
		}

		if (colisor.gameObject.tag == "ParticulaBolhas") {
			Debug.Log ("Colidiu com a bolha");
		}
	}

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag == "Finish" && !acabouJogo) {
            LabirintoController.playing = false;
            slowMotion = true;
			Score.GravaScore ();
			Finish.CarregaFinish ();
			finish.SetActive (true);

            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			//Destroy (this.gameObject);

			//SceneManager.LoadScene(nextScene, LoadSceneMode.Single);

			//SceneManager.LoadScene(PlayerPrefs.GetString("labNext"), LoadSceneMode.Additive);
			//SceneManager.UnloadScene (PlayerPrefs.GetString("labCurrent"));
		}

		if (colisor.gameObject.tag == "ParticulaBolhas") {
			Debug.Log ("Colidiu com a bolha");
		}

		if ((colisor.gameObject.tag == "Enemy" || colisor.gameObject.tag == "Obstacle") && !acabouJogo) {
			Bubble.hp -= 1;

			if (Bubble.hp <= 0)
			{
				Death ();
			}
		}
	}

	void FixedUpdate()
	{
		PlayerPrefs.SetInt ("move", moveUP);

		// Startando o game
		if (Bubble.iniciouJogo) {
			Bubble.iniciouJogo = false;
			acabouJogo = false;
			GetComponent<Rigidbody2D> ().isKinematic = false;
			//gameEngine.SendMessage ("ComecouJogo");
		}

        // Camera lenta quando o personagem termina o seguimento.
        if (slowMotion)
        {
            Time.timeScale = 0.3f;
        }

		animTop = Physics2D.Linecast (transform.position, colisorTop.position, 1 << LayerMask.NameToLayer ("Obstacle"));
        animTop = (animTop ? animTop : Physics2D.Linecast(transform.position, colisorTop.position, 1 << LayerMask.NameToLayer("Enemy")));
		anim.SetBool ("ColisorTop", animTop);

		animBottom = Physics2D.Linecast (transform.position, colisorBottom.position, 1 << LayerMask.NameToLayer ("Obstacle"));
        animBottom = (animBottom ? animBottom : Physics2D.Linecast(transform.position, colisorBottom.position, 1 << LayerMask.NameToLayer("Enemy")));
		anim.SetBool ("ColisorBottom", animBottom);

		animLeft = Physics2D.Linecast (transform.position, colisorLeft.position, 1 << LayerMask.NameToLayer ("Obstacle"));
        animLeft = (animLeft ? animLeft : Physics2D.Linecast(transform.position, colisorLeft.position, 1 << LayerMask.NameToLayer("Enemy")));
		anim.SetBool ("ColisorLeft", animLeft);

		animRight = Physics2D.Linecast (transform.position, colisorRight.position, 1 << LayerMask.NameToLayer ("Obstacle"));
        animRight = (animRight ? animRight : Physics2D.Linecast(transform.position, colisorRight.position, 1 << LayerMask.NameToLayer("Enemy")));
		anim.SetBool ("ColisorRight", animRight);


		// Reinicia o game para o tamanho ------------------------------------------
		if (transform.localScale.x < 0.30 && !acabouJogo) {
            Bubble.hp -= 1;

            if (Bubble.hp <= 0)
            {
                Death();
            }
		}
	}


	// Update is called once per frame
	void Update ()
	{
        if (LabirintoController.playing)
        {
            Debug.Log("playing está true.");
//#if PLATFORM_ANDROID || PLATAFORM_IOS
            // Controle para dispositivos mobile
            if (Input.touchCount > 0) {
                //Touch toque = Input.touches [0];

                Touch toque = Input.GetTouch(0);

				switch (toque.phase) {
				    case TouchPhase.Began:
                            // Comandos ao tocar na tela
					    actionTouch = true;
					    touchBegan = toque.position;
					    break;
				    case TouchPhase.Ended:
                            // Comandos ao tirar o dedo da tela
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
						    } else if (difX > 200f) {
							    body.AddForce (new Vector2 (moveSpeed * 2, 0f));
						    } else if (difX < -200f) {
							    body.AddForce (new Vector2 ((moveSpeed * 2) * -1, 0f));
						    } else if (difY > 100f) {
							    if (moveUP > 0) {
								    body.AddForce (new Vector2 (0f, moveSpeed));
								    anim.Play ("Move");
								    float sizeTemp = transform.localScale.x - 0.04f;
								    if (SoundTrack.sounds)
									    GetComponent<AudioSource> ().PlayOneShot (audioDip);
								    gameObject.transform.localScale = new Vector3 (sizeTemp, sizeTemp, sizeTemp);
								    GameObject particula = Instantiate (bolhaParticula);
								    particula.transform.position = gameObject.transform.position;
								    moveUP -= 1;
							    }
						    } else if (difY < -100f) {
							    body.AddForce (new Vector2 (0f, (moveSpeed * 2) * -1));
							    anim.Play ("Attack");
							    float sizeTemp = transform.localScale.x - 0.04f;
							    if (SoundTrack.sounds)
								    GetComponent<AudioSource> ().PlayOneShot (audioDip);
							    gameObject.transform.localScale = new Vector3 (sizeTemp, sizeTemp, sizeTemp);
							    GameObject particula = Instantiate (bolhaParticula);
							    particula.transform.position = gameObject.transform.position;

							    // Modificando pontuação inicial
							    if (Score.scoreLab > 1) {
								    Score.scoreLab -= 0.25f;
							    }
						    } else {
							    body.AddForce (new Vector2 (0f, divingSpeed));
							    float sizeTemp = transform.localScale.x - 0.02f;
							    if (SoundTrack.sounds)
								    GetComponent<AudioSource> ().PlayOneShot (audioDip);
							    gameObject.transform.localScale = new Vector3 (sizeTemp, sizeTemp, sizeTemp);
							    GameObject particula = Instantiate (bolhaParticula);
							    particula.transform.position = gameObject.transform.position;

							    // Modificando pontuação inicial
							    if (Score.scoreLab > 1) {
								    Score.scoreLab -= 0.25f;
							    }
						    }
					    }

					    break;
				    case TouchPhase.Moved:
                        // Comandos ao mover o dedo na tela;
                        this.touchDirection = toque.position - this.touchBegan;
					    break;
                    case TouchPhase.Canceled:
                            //The system cancelled tracking for the touch.

                        break;
				    case TouchPhase.Stationary:
                            // Comandos se o dedo permanecer na tela;
					    float timeTouch = toque.deltaTime;

					    if (actionTouch && timeTouch > 0.050f) {
						    actionTouch = false;

						    body.AddForce (new Vector2 (0f, divingSpeed));
						    float sizeTemp = transform.localScale.x - 0.02f;
						    if (SoundTrack.sounds)
							    GetComponent<AudioSource> ().PlayOneShot (audioDip);
						    gameObject.transform.localScale = new Vector3 (sizeTemp, sizeTemp, sizeTemp);
						    GameObject particula = Instantiate (bolhaParticula);
						    particula.transform.position = gameObject.transform.position;

						    // Modificando pontuação inicial
						    if (Score.scoreLab > 1) {
							    Score.scoreLab -= 0.25f;
						    }
					    }
					    break;
				}
			}
//#else
            else { // PARA DESKTOP E WEB
				if (Input.GetButtonDown ("Jump")) {
					body.AddForce (new Vector2 (0f, divingSpeed));
					float sizeTemp = transform.localScale.x - 0.02f;
					if (SoundTrack.sounds)
						GetComponent<AudioSource> ().PlayOneShot (audioDip);
					gameObject.transform.localScale = new Vector3 (sizeTemp, sizeTemp, sizeTemp);
					GameObject particula = Instantiate (bolhaParticula);
					particula.transform.position = gameObject.transform.position;

					// Modificando pontuação inicial
					if (Score.scoreLab > 1) {
						Score.scoreLab -= 0.25f;
					}
				}
				if (Input.GetAxis ("Vertical") > 0) {
					//if (moveUP > 0) {
						anim.Play ("Move");
						body.AddForce (new Vector2 (0f, moveSpeed / 3));
						moveUP -= 1;
					//}
				}

				if (Input.GetAxis ("Horizontal") > 0) {
					body.AddForce(new Vector2 (moveSpeed / 10, 0f));
				} else if (Input.GetAxis ("Horizontal") < 0) {
					body.AddForce(new Vector2 ((moveSpeed / 10) * -1, 0f));
				}
			}
//#endif
        }

	}

	private void Death()
	{
		LabirintoController.playing = false;
		lives = PlayerPrefs.GetInt("lives") - 1;
		PlayerPrefs.SetInt("lives", lives);

		Handheld.Vibrate ();

        GameObject particula = Instantiate(bolhaParticula);
        ParticleSystem particulaFX = particula.GetComponent<ParticleSystem>();
        var main = particulaFX.main;
        main.maxParticles = 50;
        var emission = particulaFX.emission;
        emission.burstCount = (int)((50f * gameObject.transform.localScale.x) / size);
        particula.transform.position = gameObject.transform.position;

        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

		int i = Random.Range (0, audioDeath.Length);
        if (SoundTrack.sounds) GetComponent<AudioSource> ().PlayOneShot (audioDeath [i]);

		anim.SetBool ("ColisorRight", true);
		anim.SetBool ("ColisorLeft", true);
		//anim.SetBool ("Death", true);
		anim.SetBool ("Died", true);
		acabouJogo = true;

        Conquest.Estourar();
        Conquest.ZerarSemEstourar();
	}

	public void FimAnimDeath()
	{
		Debug.Log ("Volta a vida");

		if (lives > 0) {
			anim.SetBool ("Died", false);
			anim.SetBool ("Continue", true);

			Bubble.hp = 1;
			Score.scoreLab = 10f;
			//iniciouJogo = false;
			LabirintoController.startGame = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
			gameObject.transform.position = origem;
			gameObject.transform.localScale = new Vector3 (size, size, size);
			//Instantiate (prefab, origem, transform.localRotation);
			//Destroy (this.gameObject);
		} else {
			Destroy (this.gameObject);
			//txtStart.fontSize = 80;
			//txtStart.text = "Game Over";

            SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive);
		}
	}

	public void FimAnimContinue()
	{
		anim.SetBool ("Died", false);
		anim.SetBool ("Continue", true);

		Debug.Log ("Volta a vida");

		//moveSpeed = 8.0f;
		//divingSpeed = -10.0f;
		//body.gravityScale = 1f;
	}
}