using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PrototipoController : MonoBehaviour {

	public string levelMap;

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene(levelMap, LoadSceneMode.Additive);
	}
}
