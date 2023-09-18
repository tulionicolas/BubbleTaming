using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
	public Text lblTotal;
	public Text lblSubTotal;

	private float total;
	private string subTotal;

	// Use this for initialization
	void Awake ()
	{
		lblTotal.text = "Total: " + PlayerPrefs.GetFloat("score").ToString("000000");

		subTotal = "Labirinto . Caminho das Bolhas\n" +
            "\tSeguimento 01..................." + PlayerPrefs.GetFloat("m01l01Score").ToString("000") + "\n" +
            "\tSeguimento 02..................." + PlayerPrefs.GetFloat("m01l02Score").ToString("000") + "\n" +
            "\tSeguimento 03..................." + PlayerPrefs.GetFloat("m01l03Score").ToString("000") + "\n" +
            "\tSeguimento 04..................." + PlayerPrefs.GetFloat("m01l04Score").ToString("000") + "\n" +
            "\tSeguimento 05..................." + PlayerPrefs.GetFloat("m01l05Score").ToString("000") + "\n" +
            "\tSeguimento 06..................." + PlayerPrefs.GetFloat("m01l06Score").ToString("000") + "\n" +
            "\tSeguimento 07..................." + PlayerPrefs.GetFloat("m01l07Score").ToString("000") + "\n" +
            "\tSeguimento 08..................." + PlayerPrefs.GetFloat("m01l08Score").ToString("000") + "\n" +
            "\tSeguimento 09..................." + PlayerPrefs.GetFloat("m01l09Score").ToString("000") + "\n" +
            "\tSeguimento 10..................." + PlayerPrefs.GetFloat("m01l10Score").ToString("000") + "\n" +
    		"\n" +
            "Labirinto . Peixes Raivosos\n" +
            "\tSeguimento 01..................." + PlayerPrefs.GetFloat("m02l01Score").ToString("000") + "\n" +
            "\tSeguimento 02..................." + PlayerPrefs.GetFloat("m02l02Score").ToString("000") + "\n" +
            "\tSeguimento 03..................." + PlayerPrefs.GetFloat("m02l03Score").ToString("000") + "\n" +
            "\tSeguimento 04..................." + PlayerPrefs.GetFloat("m02l04Score").ToString("000") + "\n" +
            "\tSeguimento 05..................." + PlayerPrefs.GetFloat("m02l05Score").ToString("000") + "\n" +
            "\tSeguimento 06..................." + PlayerPrefs.GetFloat("m02l06Score").ToString("000") + "\n" +
            "\tSeguimento 07..................." + PlayerPrefs.GetFloat("m02l07Score").ToString("000") + "\n" +
            "\tSeguimento 08..................." + PlayerPrefs.GetFloat("m02l08Score").ToString("000") + "\n" +
            "\tSeguimento 09..................." + PlayerPrefs.GetFloat("m02l09Score").ToString("000") + "\n" +
            "\tSeguimento 10..................." + PlayerPrefs.GetFloat("m02l10Score").ToString("000") + "\n" +
            "\n" +
            "Labirinto . Lixo Marítimo\n" +
            "\tSeguimento 01..................." + PlayerPrefs.GetFloat("m03l01Score").ToString("000") + "\n" +
            "\tSeguimento 02..................." + PlayerPrefs.GetFloat("m03l02Score").ToString("000") + "\n" +
            "\tSeguimento 03..................." + PlayerPrefs.GetFloat("m03l03Score").ToString("000") + "\n" +
            "\tSeguimento 04..................." + PlayerPrefs.GetFloat("m03l04Score").ToString("000") + "\n" +
            "\tSeguimento 05..................." + PlayerPrefs.GetFloat("m03l05Score").ToString("000") + "\n" +
            "\tSeguimento 06..................." + PlayerPrefs.GetFloat("m03l06Score").ToString("000") + "\n" +
            "\tSeguimento 07..................." + PlayerPrefs.GetFloat("m03l07Score").ToString("000") + "\n" +
            "\tSeguimento 08..................." + PlayerPrefs.GetFloat("m03l08Score").ToString("000") + "\n" +
            "\tSeguimento 09..................." + PlayerPrefs.GetFloat("m03l09Score").ToString("000") + "\n" +
            "\tSeguimento 10..................." + PlayerPrefs.GetFloat("m03l10Score").ToString("000") + "\n" +
    		"\n" +
            "Labirinto . Labirinto de Algas\n" +
            "\tSeguimento 01..................." + PlayerPrefs.GetFloat("m04l01Score").ToString("000") + "\n" +
            "\tSeguimento 02..................." + PlayerPrefs.GetFloat("m04l02Score").ToString("000") + "\n" +
            "\tSeguimento 03..................." + PlayerPrefs.GetFloat("m04l03Score").ToString("000") + "\n" +
            "\tSeguimento 04..................." + PlayerPrefs.GetFloat("m04l04Score").ToString("000") + "\n" +
            "\tSeguimento 05..................." + PlayerPrefs.GetFloat("m04l05Score").ToString("000") + "\n" +
            "\tSeguimento 06..................." + PlayerPrefs.GetFloat("m04l06Score").ToString("000") + "\n" +
            "\tSeguimento 07..................." + PlayerPrefs.GetFloat("m04l07Score").ToString("000") + "\n" +
            "\tSeguimento 08..................." + PlayerPrefs.GetFloat("m04l08Score").ToString("000") + "\n" +
            "\tSeguimento 09..................." + PlayerPrefs.GetFloat("m04l09Score").ToString("000") + "\n" +
            "\tSeguimento 10..................." + PlayerPrefs.GetFloat("m04l10Score").ToString("000") + "\n" +
    		"\n" +
            "Labirinto . Destroços Navais\n" +
            "\tSeguimento 01..................." + PlayerPrefs.GetFloat("m05l01Score").ToString("000") + "\n" +
            "\tSeguimento 02..................." + PlayerPrefs.GetFloat("m05l02Score").ToString("000") + "\n" +
            "\tSeguimento 03..................." + PlayerPrefs.GetFloat("m05l03Score").ToString("000") + "\n" +
            "\tSeguimento 04..................." + PlayerPrefs.GetFloat("m05l04Score").ToString("000") + "\n" +
            "\tSeguimento 05..................." + PlayerPrefs.GetFloat("m05l05Score").ToString("000") + "\n" +
            "\tSeguimento 06..................." + PlayerPrefs.GetFloat("m05l06Score").ToString("000") + "\n" +
            "\tSeguimento 07..................." + PlayerPrefs.GetFloat("m05l07Score").ToString("000") + "\n" +
            "\tSeguimento 08..................." + PlayerPrefs.GetFloat("m05l08Score").ToString("000") + "\n" +
            "\tSeguimento 09..................." + PlayerPrefs.GetFloat("m05l09Score").ToString("000") + "\n" +
            "\tSeguimento 10..................." + PlayerPrefs.GetFloat("m05l10Score").ToString("000") + "\n" +
    		"\n" +
            "Labirinto . As Profundezas\n" +
            "\tSeguimento 01..................." + PlayerPrefs.GetFloat("m06l01Score").ToString("000") + "\n" +
            "\tSeguimento 02..................." + PlayerPrefs.GetFloat("m06l02Score").ToString("000") + "\n" +
            "\tSeguimento 03..................." + PlayerPrefs.GetFloat("m06l03Score").ToString("000") + "\n" +
            "\tSeguimento 04..................." + PlayerPrefs.GetFloat("m06l04Score").ToString("000") + "\n" +
            "\tSeguimento 05..................." + PlayerPrefs.GetFloat("m06l05Score").ToString("000") + "\n" +
            "\tSeguimento 06..................." + PlayerPrefs.GetFloat("m06l06Score").ToString("000") + "\n" +
            "\tSeguimento 07..................." + PlayerPrefs.GetFloat("m06l07Score").ToString("000") + "\n" +
            "\tSeguimento 08..................." + PlayerPrefs.GetFloat("m06l08Score").ToString("000") + "\n" +
            "\tSeguimento 09..................." + PlayerPrefs.GetFloat("m06l09Score").ToString("000") + "\n" +
            "\tSeguimento 10..................." + PlayerPrefs.GetFloat("m06l10Score").ToString("000");

		lblSubTotal.text = subTotal;
	}

	public void ExitScore()
	{
		SceneManager.UnloadScene ("Score");
	}
}
