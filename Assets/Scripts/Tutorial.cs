using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Tutorial : MonoBehaviour {

    void Awake()
    {
        Time.timeScale = 0;
    }

    public void Return()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("tutorial");
    }
}
