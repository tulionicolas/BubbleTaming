using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MundoMaps : MonoBehaviour
{
	public Button btnL01;
	public Button btnL02;
	public Button btnL03;
	public Button btnL04;
	public Button btnL05;
	public Button btnL06;
	public Button btnL07;
	public Button btnL08;
	public Button btnL09;
	public Button btnL10;

	public string l01;
	public string l02;
	public string l03;
	public string l04;
	public string l05;
	public string l06;
	public string l07;
	public string l08;
	public string l09;
	public string l10;

    public RectTransform localMap;
    private float localMapX;
    private float localMapY;
    private string namePositonX;
    private string namePositonY;

	private string map;

	private int progresso = 0;
	IEnumerator CenaDeCarregamento (string cena) {

		AsyncOperation Carregamento = SceneManager.LoadSceneAsync(cena, LoadSceneMode.Additive);
		while (!Carregamento.isDone) {
			progresso = (int)(Carregamento.progress * 100);
			Debug.Log ("Loading . " + progresso.ToString());
			yield return null;
		}
	}

	void Awake ()
	{
        Time.timeScale = 1f;
		map = PlayerPrefs.GetString ("worldCurrent") + "map";

		//btnL01.interactable = (PlayerPrefs.GetInt(l01) == 0 ? false : true);
        btnL01.interactable = (PlayerPrefs.GetInt(l01) == 0 ? false : true);
        btnL02.interactable = (PlayerPrefs.GetInt(l02) == 0 ? false : true);
		btnL03.interactable = (PlayerPrefs.GetInt(l03) == 0 ? false : true);
		btnL04.interactable = (PlayerPrefs.GetInt(l04) == 0 ? false : true);
		btnL05.interactable = (PlayerPrefs.GetInt(l05) == 0 ? false : true);
		btnL06.interactable = (PlayerPrefs.GetInt(l06) == 0 ? false : true);
		btnL07.interactable = (PlayerPrefs.GetInt(l07) == 0 ? false : true);
		btnL08.interactable = (PlayerPrefs.GetInt(l08) == 0 ? false : true);
		btnL09.interactable = (PlayerPrefs.GetInt(l09) == 0 ? false : true);
        btnL10.interactable = (PlayerPrefs.GetInt(l10) == 0 ? false : true);

        string l01Score = l01 + "Score";
        string l02Score = l02 + "Score";
        string l03Score = l03 + "Score";
        string l04Score = l04 + "Score";
        string l05Score = l05 + "Score";
        string l06Score = l06 + "Score";
        string l07Score = l07 + "Score";
        string l08Score = l08 + "Score";
        string l09Score = l09 + "Score";
        string l10Score = l10 + "Score";

        btnL01.GetComponentInChildren<Text>().text = (PlayerPrefs.GetInt(l01) == 1 && PlayerPrefs.GetFloat(l01Score).Equals(0f) ? "Jogar" : "");
        btnL02.GetComponentInChildren<Text>().text = (PlayerPrefs.GetInt(l02) == 1 && PlayerPrefs.GetFloat(l02Score).Equals(0f) ? "Jogar" : "");
        btnL03.GetComponentInChildren<Text>().text = (PlayerPrefs.GetInt(l03) == 1 && PlayerPrefs.GetFloat(l03Score).Equals(0f) ? "Jogar" : "");
        btnL04.GetComponentInChildren<Text>().text = (PlayerPrefs.GetInt(l04) == 1 && PlayerPrefs.GetFloat(l04Score).Equals(0f) ? "Jogar" : "");
        btnL05.GetComponentInChildren<Text>().text = (PlayerPrefs.GetInt(l05) == 1 && PlayerPrefs.GetFloat(l05Score).Equals(0f) ? "Jogar" : "");
        btnL06.GetComponentInChildren<Text>().text = (PlayerPrefs.GetInt(l06) == 1 && PlayerPrefs.GetFloat(l06Score).Equals(0f) ? "Jogar" : "");
        btnL07.GetComponentInChildren<Text>().text = (PlayerPrefs.GetInt(l07) == 1 && PlayerPrefs.GetFloat(l07Score).Equals(0f) ? "Jogar" : "");
        btnL08.GetComponentInChildren<Text>().text = (PlayerPrefs.GetInt(l08) == 1 && PlayerPrefs.GetFloat(l08Score).Equals(0f) ? "Jogar" : "");
        btnL09.GetComponentInChildren<Text>().text = (PlayerPrefs.GetInt(l09) == 1 && PlayerPrefs.GetFloat(l09Score).Equals(0f) ? "Jogar" : "");
        btnL10.GetComponentInChildren<Text>().text = (PlayerPrefs.GetInt(l10) == 1 && PlayerPrefs.GetFloat(l10Score).Equals(0f) ? "Jogar" : "");


        //namePositonX = PlayerPrefs.GetString("worldCurrent") + "PositonX";
        //namePositonY = PlayerPrefs.GetString("worldCurrent") + "PositonY";
        if (PlayerPrefs.GetFloat(namePositonX).Equals(0) && PlayerPrefs.GetFloat(namePositonY).Equals(0))
        {
            localMapX = localMap.localPosition.x;
            localMapY = localMap.localPosition.y;

            PlayerPrefs.SetFloat(namePositonX, localMapX);
            PlayerPrefs.SetFloat(namePositonY, localMapY);
        } else {
            localMapX = PlayerPrefs.GetFloat(namePositonX);
            localMapY = PlayerPrefs.GetFloat(namePositonY);

            localMap.localPosition = new Vector3(PlayerPrefs.GetFloat(namePositonX), PlayerPrefs.GetFloat(namePositonY), 0f);
        }
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Destroy(GameObject.Find("SoundTrack"));
            SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        }

        if (!localMap.localPosition.x.Equals(localMapX) || !localMap.localPosition.y.Equals(localMapY)) {
            localMapX = localMap.localPosition.x;
            localMapY = localMap.localPosition.y;

            //PlayerPrefs.SetFloat(namePositonX, localMapX);
            //PlayerPrefs.SetFloat(namePositonY, localMapY);

            //print("New positon");
            //Debug.Log("X: " + localMapX.ToString());
            //Debug.Log("Y: " + localMapY.ToString());
        }
    }

    private void CarregaLabirinto(string labirinto)
	{
		//SceneManager.UnloadSceneAsync(map);
        SceneManager.LoadSceneAsync(labirinto, LoadSceneMode.Single);
	}

	public void CarregaLab01() { CarregaLabirinto (l01); }

	public void CarregaLab02() { CarregaLabirinto (l02); }

	public void CarregaLab03() { CarregaLabirinto (l03); }

	public void CarregaLab04() { CarregaLabirinto (l04); }

	public void CarregaLab05() { CarregaLabirinto (l05); }

	public void CarregaLab06() { CarregaLabirinto (l06); }

	public void CarregaLab07() { CarregaLabirinto (l07); }

	public void CarregaLab08() { CarregaLabirinto (l08); }

	public void CarregaLab09() { CarregaLabirinto (l09); }

	public void CarregaLab10() { CarregaLabirinto (l10); }

	public void btnNext()
	{
        Destroy(GameObject.Find("SoundTrack"));
		SceneManager.LoadSceneAsync(PlayerPrefs.GetString ("worldNext"), LoadSceneMode.Single);
	}

	public void btnPrevious()
	{
        Destroy(GameObject.Find("SoundTrack"));
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString ("worldPrevious"), LoadSceneMode.Single);
	}

	public void btnMenu()
    {
        Destroy(GameObject.Find("SoundTrack"));
        SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
	}
}
