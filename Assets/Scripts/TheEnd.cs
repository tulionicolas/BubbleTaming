using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TheEnd : MonoBehaviour {

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void btnMenu()
    {
        SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
    }
}
