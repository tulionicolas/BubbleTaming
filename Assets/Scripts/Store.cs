using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Store : MonoBehaviour {

    private int vidas;
    private int conchas;
    private int move;

    const int ADSVidas1 = 2;
    const int ADSVidas2 = 6;
    const int ADSConcha1 = 0;
    const int ADSConcha2 = 1;
    const int ADSMove2 = 2;

    const int lojaVidasTemp = 10;
    const int lojaConhaTemp = 1;
    const int lojaMoveTemp = 2;

    const int lojaVidas1= 100;
    const int lojaVidas2 = 10000;
    const int lojaConcha1 = 20;
    const int lojaConcha2 = 2000;
    const int lojamove1 = 10;
    const int lojamove2 = 1000;

    public Text qtdVidas;
    public Text qtdConchas;
    public Text qtdMove;


    // Use this for initialization
    void Start()
    {
        //Time.timeScale = 1f;

        vidas = PlayerPrefs.GetInt("lives");
        conchas = PlayerPrefs.GetInt("shells");
        move = PlayerPrefs.GetInt("move");

        AtualizaItens();
    }

    public void Return()
    {
        SceneManager.UnloadSceneAsync("store");
    }

    private void AtualizaItens()
    {
        qtdVidas.text = PlayerPrefs.GetInt("lives").ToString();
        qtdConchas.text = PlayerPrefs.GetInt("shells").ToString();
        qtdMove.text = PlayerPrefs.GetInt("move").ToString();
    }


    public void btnADS(string zoneId)
    {
        if (string.IsNullOrEmpty(zoneId)) { zoneId = null; }
        ShowOptions options = new ShowOptions();
        options.resultCallback = HadleShowResult;

        if (Advertisement.IsReady())
        {
            Advertisement.Show(zoneId, options);
        }
    }

    void HadleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                // o video não pode ser carregado.
                break;
            case ShowResult.Finished:
                vidas = (vidas < 0 ? 0 : vidas) + ADSVidas2;
                conchas = (conchas < 0 ? 0 : conchas) + ADSConcha2;
                move = (move < 0 ? 0 : move) + ADSMove2;

                PlayerPrefs.SetInt("lives", vidas);
                PlayerPrefs.SetInt("shells", conchas);
                PlayerPrefs.SetInt("move", move);
                break;
            case ShowResult.Skipped:
                vidas = (vidas < 0 ? 0 : vidas) + ADSVidas1;
                conchas = (conchas < 0 ? 0 : conchas) + ADSConcha1;

                PlayerPrefs.SetInt("lives", vidas);
                PlayerPrefs.SetInt("shells", conchas);
                break;
        }

        AtualizaItens();

    }

    public void btnLoja()
    {
        vidas = (vidas < 0 ? 0 : vidas) + lojaVidasTemp;
        conchas = (conchas < 0 ? 0 : conchas) + lojaConhaTemp;
        move = (move < 0 ? 0 : move) + lojaMoveTemp;

        PlayerPrefs.SetInt("lives", vidas);
        PlayerPrefs.SetInt("shells", conchas);
        PlayerPrefs.SetInt("move", move);

        AtualizaItens();

    }
}
