using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pauser : MonoBehaviour
{
	private string map;

	//Score
	private float scoreTotal;
	public Text lblScore;

    public Toggle uiMusic;
    public Toggle uiSounds;

    private bool _music;
    public bool Music
    {
        get { return _music; }
        set
        {
            _music = value;
            if (_music) {
                PlayerPrefs.SetInt("music", 1);
                SoundTrack.music = true;
            }
            else {
                PlayerPrefs.SetInt("music", 0);
                SoundTrack.music = false;
            }
                
        }
    }

    private bool _sounds;
    public bool Sounds
    {
        get { return _sounds; }
        set
        {
            _sounds = value;
            if (_sounds) {
                PlayerPrefs.SetInt("sounds", 1);
                SoundTrack.sounds = true;
            }
            else {
                PlayerPrefs.SetInt("sounds", 0);
                SoundTrack.sounds = false;
            }
        }
    }

	void Awake()
	{
		map = PlayerPrefs.GetString ("worldCurrent") + "map";

        Music = (PlayerPrefs.GetInt("music") == 1 ? true : false);
        Sounds = (PlayerPrefs.GetInt("sounds") == 1 ? true : false);

        uiMusic.isOn = (PlayerPrefs.GetInt("music") == 1 ? true : false);
        uiSounds.isOn = (PlayerPrefs.GetInt("sounds") == 1 ? true : false);

		scoreTotal = PlayerPrefs.GetFloat ("score");
		lblScore.text = "Score: " + scoreTotal.ToString ("000000");
	}

	public void btnReturnLevel()
	{
        LabirintoController.playing = true;
        Time.timeScale = 1;

        SceneManager.UnloadSceneAsync("Pauser");
	}

	public void btnReturnWorld()
	{
        Time.timeScale = 1;

        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("worldCurrent"), LoadSceneMode.Single);
	}

    public void btnMenu()
    {
        Destroy(GameObject.Find("SoundTrack"));

        SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        
    }
}
