using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;



public class Finish : MonoBehaviour
{
	public bool endWorld = false; 
	public GameObject[] itensLevel;

	private float score;
	private float scoreLab;
	private float scoreLabRecord;

	public Text uiScore;
	public Text uiScoreLab;
	public Text uiScoreLabRecord;
	public Text uiBtnNext;
	public Text uiBtnMap;

	private static bool nextWorld = false;

	void Start()
	{
		Finish.nextWorld = this.endWorld;

		uiBtnNext.text = "Proximo";
		uiBtnMap.text = "Todos labirintos";
	}


	void FixedUpdate()
	{
		string nameScore = PlayerPrefs.GetString ("labCurrent") + "Score";

		score = PlayerPrefs.GetFloat ("score");
		scoreLab = PlayerPrefs.GetFloat ("scoreLab");
		scoreLabRecord = PlayerPrefs.GetFloat (nameScore);

		uiScoreLab.text = "Pontos - " + scoreLab.ToString ("000");
		uiScoreLabRecord.text = "Recorde labirinto - " + scoreLabRecord.ToString ("000");
		uiScore.text = "Pontuação TOTAL - " + score.ToString ("000000");
	}

	public static void CarregaFinish()
	{
		// ex.: m01l01
		string labCurrent = PlayerPrefs.GetString ("labCurrent");
		string labNext = PlayerPrefs.GetString ("labNext");

		PlayerPrefs.SetInt (labNext, 1);

		//PlayerPrefs.SetInt("qtdFim", PlayerPrefs.GetInt("qtdFim") + 1);
		//GPSConquistas.Validar ();

		if (Finish.nextWorld) {
			PlayerPrefs.SetInt (PlayerPrefs.GetString ("worldNext"), 1);
		}

        Conquest.ZerarEstourar();
        Conquest.Passar();
        Conquest.Bichao(Score.scoreLab);
        Conquest.SemEstourar();
        Conquest.Porpouco(Bubble.size);
	}
	
	public void btnNext()
	{
		if (endWorld) {
            Destroy(GameObject.Find("SoundTrack"));
			SceneManager.LoadScene (PlayerPrefs.GetString ("worldNext"), LoadSceneMode.Single);
		} else {
			foreach (GameObject item in itensLevel) {
				Destroy (item);
			}

			//SceneManager.UnloadSceneAsync (PlayerPrefs.GetString ("labCurrent"));
            SceneManager.LoadSceneAsync (PlayerPrefs.GetString ("labNext"), LoadSceneMode.Single);
		}
	}

	public void btnReturnMapLevel()
	{
		string map = PlayerPrefs.GetString ("worldCurrent") + "map";

		//Debug.Log (PlayerPrefs.GetString("labCurrent") + " - " + PlayerPrefs.GetString("labNext"));
		SceneManager.UnloadSceneAsync(PlayerPrefs.GetString("labCurrent"));
        SceneManager.LoadSceneAsync(map, LoadSceneMode.Single);
	}
}
