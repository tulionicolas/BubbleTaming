using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        if (PlayerPrefs.GetInt("tutorial") == 0) {
            PlayerPrefs.SetInt("tutorial", 1);
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync("Tutorial", LoadSceneMode.Additive);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
        {
            //Destroy(GameObject.Find("SoundTrack"));
            //SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);

            string world = PlayerPrefs.GetString("worldCurrent");
            SceneManager.LoadSceneAsync(world, LoadSceneMode.Single);
        }
	}

    public void btnPauser()
    {
        LabirintoController.playing = false;
        Time.timeScale = 0f;

        SceneManager.LoadSceneAsync("Pauser", LoadSceneMode.Additive); 
    }
}
