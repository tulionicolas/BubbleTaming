using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MundoController : MonoBehaviour
{
	public string worldPrevious;
	public string worldCurrent;
	public string worldNext;
	//public string mapCurrent;
	//public string mapNext;

	void Start () {
		string map = worldCurrent + "map";

		PlayerPrefs.SetString ("worldPrevious", worldPrevious);
		PlayerPrefs.SetString ("worldCurrent", worldCurrent);
		PlayerPrefs.SetString ("worldNext", worldNext);

		SceneManager.LoadScene(map, LoadSceneMode.Additive);
	}
}