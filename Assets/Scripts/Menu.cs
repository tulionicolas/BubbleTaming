using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class Menu : MonoBehaviour
{
	public Text title;
	public Text lblCreditos;

	public GameObject pnlBackground;
	public GameObject pnlMenu;
	public GameObject pnlOption;
	public GameObject pnlCreditos;
	public GameObject pnlScore;
    public GameObject pnlReset;

	public Text textBtnStart;
	public Text textBtnOption;
	public Text textBtnCreditos;
	public Text textBtnScore;

	public Text textBtnMusic;
	public Text textBtnSounds;
	public Text textBtnLanguage;
	public Text textBtnControl;
	public Text textBtnReset;

	public Toggle uiMusic;
	public Toggle uiSounds;

	public Dropdown uiLanguagem;
	public Dropdown uiControl;

    public Button btnStart;

	private bool _music;
	public bool Music
	{
		get { return _music; }
		set { 
			_music = value;
            if (_music) {
                PlayerPrefs.SetInt("music", 1);
                SoundTrack.music = true;
            } else {
                PlayerPrefs.SetInt("music", 0);
                SoundTrack.music = false;
            }
				
		}
	}

	private bool _sounds;
	public bool Sounds
	{
		get { return _sounds; }
		set { 
			_sounds = value;
            if (_sounds)
            {
                PlayerPrefs.SetInt("sounds", 1);
                SoundTrack.sounds = true;
            } else {
                PlayerPrefs.SetInt("sounds", 0);
                SoundTrack.sounds = false;
            }
		}
	}

	public int _selectLanguage;
	public int SelectLanguage
	{
		get { return _selectLanguage; }
		set {
			_selectLanguage = value;
			if (_selectLanguage == 1) {
				PlayerPrefs.SetInt ("language", 1);
				Language.Portugues ();
			} else {
				PlayerPrefs.SetInt ("language", 0);
				Language.English ();
			}
			UpdateLanguage ();
		}
	}

	public int _selectControl;
	public int SelectControl
	{
		get { return _selectControl; }
		set {
			_selectControl = value;
			if (_selectControl == 1) {
				// Joystick Virtual
				PlayerPrefs.SetInt ("control", 1);
			} else {
				// Touch
				PlayerPrefs.SetInt ("control", 0);
			}

		}
	}

	private int progresso = 0;
	IEnumerator CenaDeCarregamento (string cena) {

		AsyncOperation Carregamento = SceneManager.LoadSceneAsync(cena, LoadSceneMode.Single);
		while (!Carregamento.isDone) {
			progresso = (int)(Carregamento.progress * 100);
			Debug.Log ("Loading . " + progresso.ToString());
			yield return null;
		}
	}

	// Use this for initialization
	void Start ()
	{
        Time.timeScale = 1;

		//Somente para Dev
		InfiniteLife();

        Language.Carregar ();

        btnStart.interactable = (PlayerPrefs.GetInt("lives") <= 0 ? false : true);

		Music = (PlayerPrefs.GetInt("music") == 1 ? true : false);
		Sounds = (PlayerPrefs.GetInt("sounds") == 1 ? true : false);

		uiMusic.isOn = (PlayerPrefs.GetInt("music") == 1 ? true : false);
		uiSounds.isOn = (PlayerPrefs.GetInt("sounds") == 1 ? true : false);
		uiLanguagem.value = PlayerPrefs.GetInt ("language");
		uiControl.value = PlayerPrefs.GetInt ("control");

		pnlBackground.SetActive (false);
		pnlCreditos.SetActive (false);
		pnlOption.SetActive (false);
		pnlScore.SetActive (false);
		pnlMenu.SetActive (true);

		title.text = "Bubble Taming";
		UpdateLanguage ();
	}

    private void Update()
    {
        btnStart.interactable = (PlayerPrefs.GetInt("lives") <= 0 ? false : true);

        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }

	private void InfiniteLife()
	{
        PlayerPrefs.SetInt("lives", 88);
        PlayerPrefs.SetInt("attack", 8);
        PlayerPrefs.SetInt("shells", 8);
        PlayerPrefs.SetInt("seaweed", 8);
    }

    private void UpdateLanguage()
	{
		textBtnStart.text = Language.startGame;
		textBtnOption.text = Language.options;
		textBtnCreditos.text = Language.credits;
		//textBtnScore.text = Language.score;

		lblCreditos.text = Language.creditsText;

		textBtnMusic.text = Language.music;
		textBtnSounds.text = Language.sounds;
		textBtnLanguage.text = Language.language;
		textBtnControl.text = Language.control;
		textBtnReset.text = Language.resetSaved;
	}

	public void InitGame()
	{
		if (PlayerPrefs.GetInt("m06") == 1) {
            SceneManager.LoadSceneAsync("m06", LoadSceneMode.Single);
		} else if (PlayerPrefs.GetInt("m05") == 1)
            SceneManager.LoadSceneAsync("m05", LoadSceneMode.Single);
		else if (PlayerPrefs.GetInt("m04") == 1)
            SceneManager.LoadSceneAsync("m04", LoadSceneMode.Single);
		else if (PlayerPrefs.GetInt("m03") == 1)
            SceneManager.LoadSceneAsync("m03", LoadSceneMode.Single);
		else if (PlayerPrefs.GetInt("m02") == 1)
            SceneManager.LoadSceneAsync("m02", LoadSceneMode.Single);
		else {
			SceneManager.LoadSceneAsync("m01", LoadSceneMode.Single);
		}
	}

	public void Option()
	{
		title.text = Language.options;

		pnlMenu.SetActive (false);
		pnlBackground.SetActive (true);
		pnlOption.SetActive (true);
	}

	public void Creditos()
	{
		title.text = "Credits";

		pnlMenu.SetActive (false);
		pnlBackground.SetActive (true);
		pnlCreditos.SetActive (true);
	}

	public void Tutorial()
	{
		//title.text = "Tutorial";

		//pnlMenu.SetActive (false);
		//pnlBackground.SetActive (true);
        SceneManager.LoadSceneAsync("tutorial", LoadSceneMode.Additive);
	}

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Loja()
    {
        SceneManager.LoadSceneAsync("store", LoadSceneMode.Additive);
    }

	public void Score()
	{
        if (Social.localUser.authenticated)
        {
            float scoreTotal = PlayerPrefs.GetFloat("score");
            Social.ReportScore((int)scoreTotal, "CodigoScoreGooglePlay", (bool sucesso) => {
            });
            //PlayGamesPlatform.Instance.ShowLeaderboardUI("CodigoGooglePlay");
        }
        else
        {
            //SceneManager.LoadScene("Score", LoadSceneMode.Additive);
            title.text = "Score";

            pnlMenu.SetActive(false);
            pnlBackground.SetActive(true);
            pnlScore.SetActive(true);
        }
	}

    public void Conquest()
    {
		//if (Social.localUser.authenticated) {
			//Social.ShowAchievementsUI ();
		//} else {
			SceneManager.LoadSceneAsync ("conquest", LoadSceneMode.Additive);
		//}
    }

	public void Return()
	{
		title.text = "Bubble Taming";

		pnlCreditos.SetActive (false);
		pnlOption.SetActive (false);
		pnlScore.SetActive (false);
		pnlBackground.SetActive (false);

		pnlMenu.SetActive (true);

	}

    public void ResetGame()
    {
        pnlReset.SetActive(true);
    }

    public void ResetNo()
    {
        pnlReset.SetActive(false);
    }

    public void ResetYes()
    {
        PlayerPrefs.SetInt("inicializado", 0);
        SceneManager.LoadSceneAsync("Splash", LoadSceneMode.Single);
    }
}
