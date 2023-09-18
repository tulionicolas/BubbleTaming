using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.UI;


public class GameOver : MonoBehaviour {

    private int vidas;
    private int conchas;
    private int move;

    const int ADSVidas2 = 6;
    const int ADSVidas1 = 2;
    const int ADSConchas1 = 0;
    const int ADSConchas2 = 1;
    const int ADSMove = 2;

    const int lojaVidasTemp = 10;
    const int lojaConchaTemp = 1;
    const int lojaMoveTemp = 2;

    private string level;
    private string world;


	// Use this for initialization
	void Start () {
        Time.timeScale = 0.3f;

        vidas = PlayerPrefs.GetInt("lives");
        conchas = PlayerPrefs.GetInt("shells");
        move = PlayerPrefs.GetInt("move");

        world = PlayerPrefs.GetString("worldCurrent");
        level = PlayerPrefs.GetString("labCurrent");
	}

    public void Return()
    {
        if (PlayerPrefs.GetInt("lives") > 0) {
            try
            {
                SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);
            }
            catch (System.Exception)
            {
                SceneManager.LoadSceneAsync(world, LoadSceneMode.Single);
            }
        } else {
            Destroy(GameObject.Find("SoundTrack"));
            SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        }
    }

    public void btnADS(string zoneId)
    {
        if(string.IsNullOrEmpty(zoneId)) { zoneId = null; }
        ShowOptions options = new ShowOptions();
        options.resultCallback = HadleShowResult;

        if (Advertisement.IsReady())
        {
            Advertisement.Show(zoneId, options);
        }
    }

    void HadleShowResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Failed:
                // o video não pode ser carregado.
                break;
            case ShowResult.Finished:
                vidas = (vidas < 0 ? 0 : vidas) + ADSVidas2;
                conchas = (conchas < 0 ? 0 : conchas) + ADSConchas2;
                move = (move < 0 ? 0 : move) + ADSMove;

                PlayerPrefs.SetInt("lives", vidas);
                PlayerPrefs.SetInt("shells", conchas);
                try
                {
                    SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);
                }
                catch (System.Exception e)
                {
                    SceneManager.LoadSceneAsync(world, LoadSceneMode.Single);
                    Debug.Log(e.Message.ToString());
                }
                break;
            case ShowResult.Skipped:
                vidas = (vidas < 0 ? 0 : vidas) + ADSVidas1;

                PlayerPrefs.SetInt("lives", vidas);
                PlayerPrefs.SetInt("shells", conchas);
                try
                {
                    SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);
                }
                catch (System.Exception e)
                {
                    SceneManager.LoadSceneAsync(world, LoadSceneMode.Single);
                    Debug.Log(e.Message.ToString());
                }
                break;
        }

    }

    public void btnLoja()
    {
        SceneManager.LoadSceneAsync("store", LoadSceneMode.Additive);

        /*
        vidas = (vidas < 0 ? 0 : vidas) + lojaVidasTemp;
        conchas = (conchas < 0 ? 0 : conchas) + lojaConchaTemp;

        PlayerPrefs.SetInt("lives", vidas);
        PlayerPrefs.SetInt("shells", conchas);

        try
        {
            SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);
        }
        catch (System.Exception e)
        {
            SceneManager.LoadSceneAsync(world, LoadSceneMode.Single);
            Debug.Log(e.Message.ToString());
        }
        */
        
    }
}
