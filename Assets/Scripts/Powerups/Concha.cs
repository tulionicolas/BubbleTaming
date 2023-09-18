using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Concha : MonoBehaviour
{
	public int hpConcha = 30;
	public Text txbConcha;
	private int qtdConcha;

	// Use this for initialization
	void Awake()
	{
		//PlayerPrefs.SetInt ("shells", 2);
		qtdConcha = PlayerPrefs.GetInt ("shells");
		txbConcha.text = qtdConcha.ToString();
	}

	public void ActivatePowerUp()
	{
        Debug.Log ("Ativando o Powerup");
        if (LabirintoController.playing)
        {
            if (qtdConcha > 0)
            {
                qtdConcha -= 1;
                PlayerPrefs.SetInt("shells", qtdConcha);
                txbConcha.text = qtdConcha.ToString();
                Bubble.hp += hpConcha;

                Debug.Log ("dentro do IF");

                //Ativa a powerup concha para ser desenvolvido as funcionalidades necessarias no player
                PowerUps.concha = true;
            }
        }
	}
}
