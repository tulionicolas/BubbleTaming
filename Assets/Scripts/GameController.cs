using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameController : MonoBehaviour
{
	public string splash = "Splash";
	public string intro = "Intro";
	public string menu = "Menu";

	void Start()
	{
        //PlayerPrefs.SetInt ("inicializado", 0); //Temporario para implementaçao

		if (PlayerPrefs.GetInt ("inicializado") != 1) {
			Language.English ();
			ConfigGame ();
		} else {
			Language.Carregar ();
		}

        SceneManager.LoadSceneAsync(menu, LoadSceneMode.Single);
		//Invoke ("CarregaIntro", 3f);
	}
		

	public void CarregaIntro()
	{
        SceneManager.LoadSceneAsync(menu, LoadSceneMode.Single);
	}

	private void ConfigGame()
	{
		if (PlayerPrefs.GetInt ("inicializado") != 1) {
			//Variavel para validar inicializacao
			PlayerPrefs.SetInt ("inicializado", 1);
			PlayerPrefs.SetInt ("control", 0);
			PlayerPrefs.SetInt ("dificulty", 2);
			PlayerPrefs.SetInt ("music", 1);
			PlayerPrefs.SetInt ("sounds", 1);
			PlayerPrefs.SetInt ("language", 0);
			PlayerPrefs.SetFloat ("score", 0);
            PlayerPrefs.SetInt("tutorial", 0);


			//Inicializado registros para conquistas --------------------------
			PlayerPrefs.SetInt("qtdFim", 0);
            PlayerPrefs.SetInt("conquestBichao", 0);
            PlayerPrefs.SetInt("conquestSortudo", 0);
            PlayerPrefs.SetInt("conquestCompra", 0);
            PlayerPrefs.SetInt("conquestPorPouco", 0);

            PlayerPrefs.SetInt("conquestJuninho", 0);
            PlayerPrefs.SetInt("conquestPassar10", 0);
            PlayerPrefs.SetInt("conquestPassar50", 0);
            PlayerPrefs.SetInt("conquestPassar100", 0);
            PlayerPrefs.SetInt("conquestPassar1000", 0);

            PlayerPrefs.SetInt("conquestEstourar10", 0);
            PlayerPrefs.SetInt("conquestEstourar50", 0);
            PlayerPrefs.SetInt("conquestEstourar100", 0);
            PlayerPrefs.SetInt("conquestEstourar500", 0);

            PlayerPrefs.SetInt("conquestSemEstourar10", 0);
            PlayerPrefs.SetInt("conquestSemEstourar30", 0);
            PlayerPrefs.SetInt("conquestSemEstourar50", 0);
            PlayerPrefs.SetInt("conquestSemEstourar60", 0);
            PlayerPrefs.SetInt("conquestSemEstourar70", 0);
            PlayerPrefs.SetInt("conquestSemEstourar100", 0);


			//Power-Up e Inventario----------------------------------------
			PlayerPrefs.SetInt ("lives", 88);
			PlayerPrefs.SetInt ("attack", 8);
			PlayerPrefs.SetInt ("shells", 8);
			PlayerPrefs.SetInt ("seaweed", 8);
			PlayerPrefs.SetInt ("gold", 0);
			PlayerPrefs.SetInt ("silver", 10);
            PlayerPrefs.SetInt("move", 5); 


            //Inicializacao dos labirintos ----------------------

            //Mundo 01
            PlayerPrefs.SetFloat("m01PositionX", 0f);
            PlayerPrefs.SetFloat("m01PositionY", 0f);
			PlayerPrefs.SetInt ("m01", 1);
			PlayerPrefs.SetInt ("m01l01", 1);
			PlayerPrefs.SetInt ("m01l02", 0);
			PlayerPrefs.SetInt ("m01l03", 0);
			PlayerPrefs.SetInt ("m01l04", 0);
			PlayerPrefs.SetInt ("m01l05", 0);
			PlayerPrefs.SetInt ("m01l06", 0);
			PlayerPrefs.SetInt ("m01l07", 0);
			PlayerPrefs.SetInt ("m01l08", 0);
			PlayerPrefs.SetInt ("m01l09", 0);
			PlayerPrefs.SetInt ("m01l10", 0);
			PlayerPrefs.SetFloat ("m01l01Score", 0);
			PlayerPrefs.SetFloat ("m01l02Score", 0);
			PlayerPrefs.SetFloat ("m01l03Score", 0);
			PlayerPrefs.SetFloat ("m01l04Score", 0);
			PlayerPrefs.SetFloat ("m01l05Score", 0);
			PlayerPrefs.SetFloat ("m01l06Score", 0);
			PlayerPrefs.SetFloat ("m01l07Score", 0);
			PlayerPrefs.SetFloat ("m01l08Score", 0);
			PlayerPrefs.SetFloat ("m01l09Score", 0);
			PlayerPrefs.SetFloat ("m01l10Score", 0);

			//Mundo 02
            PlayerPrefs.SetFloat("m02PositionX", 0f);
            PlayerPrefs.SetFloat("m02PositionY", 0f);
			PlayerPrefs.SetInt ("m02", 0);
			PlayerPrefs.SetInt ("m02l01", 0);
			PlayerPrefs.SetInt ("m02l02", 0);
			PlayerPrefs.SetInt ("m02l03", 0);
			PlayerPrefs.SetInt ("m02l04", 0);
			PlayerPrefs.SetInt ("m02l05", 0);
			PlayerPrefs.SetInt ("m02l06", 0);
			PlayerPrefs.SetInt ("m02l07", 0);
			PlayerPrefs.SetInt ("m02l08", 0);
			PlayerPrefs.SetInt ("m02l09", 0);
			PlayerPrefs.SetInt ("m02l10", 0);
			PlayerPrefs.SetFloat ("m02l01Score", 0);
			PlayerPrefs.SetFloat ("m02l02Score", 0);
			PlayerPrefs.SetFloat ("m02l03Score", 0);
			PlayerPrefs.SetFloat ("m02l04Score", 0);
			PlayerPrefs.SetFloat ("m02l05Score", 0);
			PlayerPrefs.SetFloat ("m02l06Score", 0);
			PlayerPrefs.SetFloat ("m02l07Score", 0);
			PlayerPrefs.SetFloat ("m02l08Score", 0);
			PlayerPrefs.SetFloat ("m02l09Score", 0);
			PlayerPrefs.SetFloat ("m02l10Score", 0);

			//Mundo 03
            PlayerPrefs.SetFloat("m03PositionX", 0f);
            PlayerPrefs.SetFloat("m03PositionY", 0f);
			PlayerPrefs.SetInt ("m03", 0);
			PlayerPrefs.SetInt ("m03l01", 0);
			PlayerPrefs.SetInt ("m03l02", 0);
			PlayerPrefs.SetInt ("m03l03", 0);
			PlayerPrefs.SetInt ("m03l04", 0);
			PlayerPrefs.SetInt ("m03l05", 0);
			PlayerPrefs.SetInt ("m03l06", 0);
			PlayerPrefs.SetInt ("m03l07", 0);
			PlayerPrefs.SetInt ("m03l08", 0);
			PlayerPrefs.SetInt ("m03l09", 0);
			PlayerPrefs.SetInt ("m03l10", 0);
			PlayerPrefs.SetFloat ("m03l01Score", 0);
			PlayerPrefs.SetFloat ("m03l02Score", 0);
			PlayerPrefs.SetFloat ("m03l03Score", 0);
			PlayerPrefs.SetFloat ("m03l04Score", 0);
			PlayerPrefs.SetFloat ("m03l05Score", 0);
			PlayerPrefs.SetFloat ("m03l06Score", 0);
			PlayerPrefs.SetFloat ("m03l07Score", 0);
			PlayerPrefs.SetFloat ("m03l08Score", 0);
			PlayerPrefs.SetFloat ("m03l09Score", 0);
			PlayerPrefs.SetFloat ("m03l10Score", 0);

			//Mundo 04
            PlayerPrefs.SetFloat("m04PositionX", 0f);
            PlayerPrefs.SetFloat("m04PositionY", 0f);
			PlayerPrefs.SetInt ("m04", 0);
			PlayerPrefs.SetInt ("m04l01", 0);
			PlayerPrefs.SetInt ("m04l02", 0);
			PlayerPrefs.SetInt ("m04l03", 0);
			PlayerPrefs.SetInt ("m04l04", 0);
			PlayerPrefs.SetInt ("m04l05", 0);
			PlayerPrefs.SetInt ("m04l06", 0);
			PlayerPrefs.SetInt ("m04l07", 0);
			PlayerPrefs.SetInt ("m04l08", 0);
			PlayerPrefs.SetInt ("m04l09", 0);
			PlayerPrefs.SetInt ("m04l10", 0);
			PlayerPrefs.SetFloat ("m04l01Score", 0);
			PlayerPrefs.SetFloat ("m04l02Score", 0);
			PlayerPrefs.SetFloat ("m04l03Score", 0);
			PlayerPrefs.SetFloat ("m04l04Score", 0);
			PlayerPrefs.SetFloat ("m04l05Score", 0);
			PlayerPrefs.SetFloat ("m04l06Score", 0);
			PlayerPrefs.SetFloat ("m04l07Score", 0);
			PlayerPrefs.SetFloat ("m04l08Score", 0);
			PlayerPrefs.SetFloat ("m04l09Score", 0);
			PlayerPrefs.SetFloat ("m04l10Score", 0);

			//Mundo 05
            PlayerPrefs.SetFloat("m05PositionX", 0f);
            PlayerPrefs.SetFloat("m05PositionY", 0f);
			PlayerPrefs.SetInt ("m05", 0);
			PlayerPrefs.SetInt ("m05l01", 0);
			PlayerPrefs.SetInt ("m05l02", 0);
			PlayerPrefs.SetInt ("m05l03", 0);
			PlayerPrefs.SetInt ("m05l04", 0);
			PlayerPrefs.SetInt ("m05l05", 0);
			PlayerPrefs.SetInt ("m05l06", 0);
			PlayerPrefs.SetInt ("m05l07", 0);
			PlayerPrefs.SetInt ("m05l08", 0);
			PlayerPrefs.SetInt ("m05l09", 0);
			PlayerPrefs.SetInt ("m05l10", 0);
			PlayerPrefs.SetFloat ("m05l01Score", 0);
			PlayerPrefs.SetFloat ("m05l02Score", 0);
			PlayerPrefs.SetFloat ("m05l03Score", 0);
			PlayerPrefs.SetFloat ("m05l04Score", 0);
			PlayerPrefs.SetFloat ("m05l05Score", 0);
			PlayerPrefs.SetFloat ("m05l06Score", 0);
			PlayerPrefs.SetFloat ("m05l07Score", 0);
			PlayerPrefs.SetFloat ("m05l08Score", 0);
			PlayerPrefs.SetFloat ("m05l09Score", 0);
			PlayerPrefs.SetFloat ("m05l10Score", 0);

			//Mundo 06
            PlayerPrefs.SetFloat("m06PositionX", 0f);
            PlayerPrefs.SetFloat("m06PositionY", 0f);
			PlayerPrefs.SetInt ("m06", 0);
			PlayerPrefs.SetInt ("m06l01", 0);
			PlayerPrefs.SetInt ("m06l02", 0);
			PlayerPrefs.SetInt ("m06l03", 0);
			PlayerPrefs.SetInt ("m06l04", 0);
			PlayerPrefs.SetInt ("m06l05", 0);
			PlayerPrefs.SetInt ("m06l06", 0);
			PlayerPrefs.SetInt ("m06l07", 0);
			PlayerPrefs.SetInt ("m06l08", 0);
			PlayerPrefs.SetInt ("m06l09", 0);
			PlayerPrefs.SetInt ("m06l10", 0);
			PlayerPrefs.SetFloat ("m06l01Score", 0);
			PlayerPrefs.SetFloat ("m06l02Score", 0);
			PlayerPrefs.SetFloat ("m06l03Score", 0);
			PlayerPrefs.SetFloat ("m06l04Score", 0);
			PlayerPrefs.SetFloat ("m06l05Score", 0);
			PlayerPrefs.SetFloat ("m06l06Score", 0);
			PlayerPrefs.SetFloat ("m06l07Score", 0);
			PlayerPrefs.SetFloat ("m06l08Score", 0);
			PlayerPrefs.SetFloat ("m06l09Score", 0);
			PlayerPrefs.SetFloat ("m06l10Score", 0);
		}
	}
}
