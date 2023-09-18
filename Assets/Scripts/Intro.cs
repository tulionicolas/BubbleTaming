using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Intro : MonoBehaviour
{
	public string nextScene = "Menu";
	public Text textSkipIntro;

	void Start()
	{
		textSkipIntro.text = Language.tapStart;
		Invoke ("CarregaMenu", 8f);
	}

	public void CarregaMenu()
	{
		//SceneManager.UnloadScene (intro);
        SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Single);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			//SceneManager.UnloadScene ("Intro");
            SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Single);
		}
	}
}
