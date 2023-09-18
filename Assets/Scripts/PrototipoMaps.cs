using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PrototipoMaps : MonoBehaviour
{
	public Button l01;
	public Button l02;
	public Button l03;

	public static string mapNow;
	public static string mapNext;

	void Awake ()
	{
		PlayerPrefs.SetString ("mapCurrent", "PrototipoMapLevel");
		l01.interactable = true;
		l02.interactable = (PlayerPrefs.GetInt ("pl01") == 0 ? true : true);
		l03.interactable = (PlayerPrefs.GetInt ("pl02") == 0 ? true : true);
	}

	public void CarregaMap01()
	{
		SceneManager.UnloadScene ("PrototipoMapLevel");
		SceneManager.LoadScene("PrototipoMap01", LoadSceneMode.Additive);
	}

	public void CarregaMap02()
	{
		SceneManager.UnloadScene ("PrototipoMapLevel");
		SceneManager.LoadScene("PrototipoMap02", LoadSceneMode.Additive);
	}

	public void CarregaMap03()
	{
		SceneManager.UnloadScene ("PrototipoMapLevel");
		SceneManager.LoadScene("PrototipoMap03", LoadSceneMode.Additive);
	}
}
