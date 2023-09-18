using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Alga : MonoBehaviour
{
	public int hpAlga = 5;
	public Text txbAlga;
	private int qtdAlga;

	void Awake()
	{
		qtdAlga = PlayerPrefs.GetInt ("seaweed");
		txbAlga.text = qtdAlga.ToString();
	}

	public void ActivatePowerUp()
	{
        if (LabirintoController.playing)
        {
            if (qtdAlga > 0)
            {
                qtdAlga -= 1;
                PlayerPrefs.SetInt("seaweed", qtdAlga);
                txbAlga.text = qtdAlga.ToString();
                Bubble.hp += hpAlga;

                PowerUps.alga = true;
            }
        }
	}
}
