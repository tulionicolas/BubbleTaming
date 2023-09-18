using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Conquest : MonoBehaviour {

    public Image btnBichao;
    public Image btnSortudo;
    public Image btnCompra;
    public Image btnPorpouco;
    public Image btnJuninho;
    public Image btnPassar10;
    public Image btnPassar50;
    public Image btnPassar100;
    public Image btnPassar1000;
    public Image btnEstourar10;
    public Image btnEstourar50;
    public Image btnEstourar100;
    public Image btnEstourar500;
    public Image btnSemEstourar10;
    public Image btnSemEstourar30;
    public Image btnSemEstourar50;
    public Image btnSemEstourar60;
    public Image btnSemEstourar70;
    public Image btnSemEstourar100;

    public Text titulo;
    public Text descricao;
    public GameObject pnlDescConquista;

    public int value;

	// Use this for initialization
	void Start () {
        value = 0;

        btnBichao.fillAmount = PlayerPrefs.GetInt("conquestBichao") * 1f;
        btnSortudo.fillAmount = PlayerPrefs.GetInt("conquestSortudo") * 1f;
        btnCompra.fillAmount = PlayerPrefs.GetInt("conquestCompra") * 1f;
        btnPorpouco.fillAmount = PlayerPrefs.GetInt("conquestPorPouco") * 1f;

        btnJuninho.fillAmount = PlayerPrefs.GetInt("conquestJuninho") * 1f;
        btnPassar10.fillAmount = PlayerPrefs.GetInt("conquestPassar10") * 0.10f;
        btnPassar50.fillAmount = PlayerPrefs.GetInt("conquestPassar50") * 0.02f;
        btnPassar100.fillAmount = PlayerPrefs.GetInt("conquestPassar100") * 0.01f;
        btnPassar1000.fillAmount = PlayerPrefs.GetInt("conquestPassar1000") * 0.001f;

        btnEstourar10.fillAmount = PlayerPrefs.GetInt("conquestEstourar10") * 0.10f;
        btnEstourar50.fillAmount = PlayerPrefs.GetInt("conquestEstourar50") * 0.02f;
        btnEstourar100.fillAmount = PlayerPrefs.GetInt("conquestEstourar100") * 0.01f;
        btnEstourar500.fillAmount = PlayerPrefs.GetInt("conquestEstourar500") * 0.002f;

        btnSemEstourar10.fillAmount = PlayerPrefs.GetInt("conquestSemEstourar10") * 0.10f;
        btnSemEstourar30.fillAmount = PlayerPrefs.GetInt("conquestSemEstourar30") * 0.0334f;
        btnSemEstourar50.fillAmount = PlayerPrefs.GetInt("conquestSemEstourar50") * 0.02f;
        btnSemEstourar60.fillAmount = PlayerPrefs.GetInt("conquestSemEstourar60") * 0.0167f;
        btnSemEstourar70.fillAmount = PlayerPrefs.GetInt("conquestSemEstourar70") * 0.0143f;
        btnSemEstourar100.fillAmount = PlayerPrefs.GetInt("conquestSemEstourar100") * 0.01f;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Return()
    {
        SceneManager.UnloadSceneAsync("conquest");
    }

    public void BtnFimDescricao()
    {
        pnlDescConquista.SetActive(false);
        titulo.text = "";
        descricao.text = "";
    }

    public void BtnBichao()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "You are the best";
			descricao.text = "Pass any labyrinth with 10 points without get itens.";
		} else {
			titulo.text = "Você é o bichão mesmo";
			descricao.text = "Passar qualquer labirinto com 10 pontos, sem pegar itens.";
		}

		pnlDescConquista.SetActive (true);
    }

    public void BtnSortudo()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "Lucky";
			descricao.text = "Getting the first gold coin.";
		} else {
			titulo.text = "Sortudo";
			descricao.text = "Pegando a primeiro moeda de ouro.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnCompra()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "My first item";
			descricao.text = "Buying the first PowerUp";
		} else {
			titulo.text = "Meu primeiro item";
			descricao.text = "Comprando o primeiro PowerUP.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnPorpouco()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "That was close";
			descricao.text = "Pass a labyrinth with one diving left to blow.";
		} else {
			titulo.text = "Essa foi por pouco";
			descricao.text = "Passar um labirinto faltando um mergulho para estourar.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnJuninho()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "Baby";
			descricao.text = "My first labyrinth won.";
		} else {
			titulo.text = "Juninho";
			descricao.text = "Meu primeiro labirinto vencido.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnPassar10()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "Gamer 10";
			descricao.text = "Pass 10 labyrinths.";
		} else {
			titulo.text = "Gamer nota 10";
			descricao.text = "Passar por 10 labirintos.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnPassar50()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = " Gamer 50";
			descricao.text = "Pass 50 labyrinths.";
		} else {
			titulo.text = "Gamer nota 50";
			descricao.text = "Passar por 50 labirintos.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnPassar100()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "Gamer 100";
			descricao.text = "Pass 100 labirynths.";
		} else {
			titulo.text = "Gamer nota 100";
			descricao.text = "Passar por 100 labirintos.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnPassar1000()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "Gamer 1000";
			descricao.text = "Pass 1000 labirynths.";
		} else {
			titulo.text = "Gamer nota 1000";
			descricao.text = "Passar por 1000 labirintos.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnSemEstourar10()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "The lord of Labyrinths.";
			descricao.text = "Pass 10 consecutive labyrinths without blowing the bubble.";
		} else {
			titulo.text = "Senhor dos labirintos";
			descricao.text = "Passar 10 labirintos consecutivamente sem estourar a Bolha.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnSemEstourar30()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "Master of Labyrinths";
			descricao.text = "Pass 30 consecutive labyrinths without blowing the bubble.";
		} else {
			titulo.text = "Mestre dos labirintos";
			descricao.text = "Passar 30 labirintos consecutivamente sem estourar a Bolha.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnSemEstourar50()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "God of Labyrinths";
			descricao.text = "Pass 50 consecutive labyrinths without blowing the bubble.";
		} else {
			titulo.text = "Deus dos labirintos";
			descricao.text = "Passar 50 labirintos consecutivamente sem estourar a Bolha.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnSemEstourar60()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "Are you joking?";
			descricao.text = "Pass 60 consecutive labyrinths without blowing the bubble.";
		} else {
			titulo.text = "Aí já é brincadeira";
			descricao.text = "Passar 60 labirintos consecutivamente sem estourar a Bolha.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnSemEstourar70()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "Ah, Just stop!";
			descricao.text = "Pass 70 consecutive labyrinths without blowing the bubble.";
		} else {
			titulo.text = "Aí não, para";
			descricao.text = "Passar 70 labirintos consecutivamente sem estourar a Bolha.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnSemEstourar100()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "Now, that's impossible!";
			descricao.text = "Pass 100 consecutive labyrinths without blowing the bubble.";
		} else {
			titulo.text = "Não, isso é impossível";
			descricao.text = "Passar 100 labirintos consecutivamente sem estourar a Bolha.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnEstourar10()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "What are you doing?";
			descricao.text = "Blow the bubble 10 consecutive times.";
		} else {
			titulo.text = "O que você está fazendo?";
			descricao.text = "Estourar a Bolha 10 vezes consecutivas.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnEstourar50()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "I don't think you understood the game";
			descricao.text = "Blow the bubble 50 consecutive times.";
		} else {
			titulo.text = "Acho que você não entendeu o jogo";
			descricao.text = "Estourar a Bolha 50 vezes consecutivas.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnEstourar100()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "Just give up";
			descricao.text = "Blow the bubble 100 consecutive times.";
		} else {
			titulo.text = "Desista";
			descricao.text = "Estourar a Bolha 100 vezes consecutivas.";
		}

        pnlDescConquista.SetActive(true);
    }

    public void BtnEstourar500()
    {
		if (PlayerPrefs.GetInt ("language") == 0) {
			titulo.text = "Are you still there?";
			descricao.text = "Blow the bubble 500 consecutive times.";
		} else {
			titulo.text = "Ainda você está aí?";
			descricao.text = "Estourar a Bolha 500 vezes consecutivas.";
		}

        pnlDescConquista.SetActive(true);
    }

    public static void Passar()
    {
        int passar1 = PlayerPrefs.GetInt("conquestJuninho");
        int passar10 = PlayerPrefs.GetInt("conquestPassar10");
        int passar50 = PlayerPrefs.GetInt("conquestPassar50");
        int passar100 = PlayerPrefs.GetInt("conquestPassar100");
        int passar1000 = PlayerPrefs.GetInt("conquestPassar1000");

        if (passar1 < 1)
        {
            passar1 += 1;
            PlayerPrefs.SetInt("conquestJuninho", passar1);
        }

        if (passar10 < 10)
        {
            passar10 += 1;
            PlayerPrefs.SetInt("conquestPassar10", passar10);
        }

        if (passar50 < 50)
        {
            passar50 += 1;
            PlayerPrefs.SetInt("conquestPassar50", passar50);
        }

        if (passar100 < 100)
        {
            passar100 += 1;
            PlayerPrefs.SetInt("conquestPassar100", passar100);
        }

        if (passar1000 < 1000)
        {
            passar1000 += 1;
            PlayerPrefs.SetInt("conquestPassar1000", passar1000);
        }
    }

    public static void Estourar()
    {
        int estourar10 = PlayerPrefs.GetInt("conquestEstourar10");
        int estourar50 = PlayerPrefs.GetInt("conquestEstourar50");
        int estourar100 = PlayerPrefs.GetInt("conquestEstourar100");
        int estourar500 = PlayerPrefs.GetInt("conquestEstourar500");

        if (estourar10 < 10) {
            estourar10 += 1;
            PlayerPrefs.SetInt("conquestEstourar10", estourar10);
        }

        if (estourar50 < 50)
        {
            estourar50 += 1;
            PlayerPrefs.SetInt("conquestEstourar50", estourar50);
        }

        if (estourar100 < 100)
        {
            estourar100 += 1;
            PlayerPrefs.SetInt("conquestEstourar100", estourar100);
        }

        if (estourar500 < 500)
        {
            estourar500 += 1;
            PlayerPrefs.SetInt("conquestEstourar500", estourar500);
        }
    }

    public static void ZerarEstourar()
    {
        int estourar10 = PlayerPrefs.GetInt("conquestEstourar10");
        int estourar50 = PlayerPrefs.GetInt("conquestEstourar50");
        int estourar100 = PlayerPrefs.GetInt("conquestEstourar100");
        int estourar500 = PlayerPrefs.GetInt("conquestEstourar500");

        if (estourar10 < 10)
        {
            PlayerPrefs.SetInt("conquestEstourar10", 0);
        }

        if (estourar50 < 50)
        {
            PlayerPrefs.SetInt("conquestEstourar50", 0);
        }

        if (estourar100 < 100)
        {
            PlayerPrefs.SetInt("conquestEstourar100", 0);
        }

        if (estourar500 < 500)
        {
            PlayerPrefs.SetInt("conquestEstourar500", 0);
        }
    }

    public static void Bichao(float score)
    {
        int conquestBichao = PlayerPrefs.GetInt("conquestBichao");

        if (conquestBichao < 1) {
            if (score.Equals(10.0))
                PlayerPrefs.SetInt("conquestBichao", 1);
        }
    }

    public static void Porpouco(float size)
    {
        int conquestPorpouco = PlayerPrefs.GetInt("conquestPorPouco");

        if (conquestPorpouco < 1) {
            if (size < 0.40f)
                PlayerPrefs.SetInt("conquestPorPouco", 1);
        }
    }

    public static void SemEstourar()
    {
        int semEstourar10 = PlayerPrefs.GetInt("conquestSemEstourar10");
        int semEstourar30 = PlayerPrefs.GetInt("conquestSemEstourar30");
        int semEstourar50 = PlayerPrefs.GetInt("conquestSemEstourar50");
        int semEstourar60 = PlayerPrefs.GetInt("conquestSemEstourar60");
        int semEstourar70 = PlayerPrefs.GetInt("conquestSemEstourar70");
        int semEstourar100 = PlayerPrefs.GetInt("conquestSemEstourar100");

        if (semEstourar10 < 10)
        {
            semEstourar10 += 1;
            PlayerPrefs.SetInt("conquestSemEstourar10", semEstourar10);
        }

        if (semEstourar30 < 30)
        {
            semEstourar30 += 1;
            PlayerPrefs.SetInt("conquestSemEstourar30", semEstourar30);
        }

        if (semEstourar50 < 50)
        {
            semEstourar50 += 1;
            PlayerPrefs.SetInt("conquestSemEstourar50", semEstourar50);
        }

        if (semEstourar60 < 60)
        {
            semEstourar60 += 1;
            PlayerPrefs.SetInt("conquestSemEstourar60", semEstourar60);
        }

        if (semEstourar70 < 70)
        {
            semEstourar70 += 1;
            PlayerPrefs.SetInt("conquestSemEstourar70", semEstourar70);
        }

        if (semEstourar100 < 100)
        {
            semEstourar100 += 1;
            PlayerPrefs.SetInt("conquestSemEstourar100", semEstourar100);
        }

    }

    public static void ZerarSemEstourar()
    {
        int semEstourar10 = PlayerPrefs.GetInt("conquestSemEstourar10");
        int semEstourar30 = PlayerPrefs.GetInt("conquestSemEstourar30");
        int semEstourar50 = PlayerPrefs.GetInt("conquestSemEstourar50");
        int semEstourar60 = PlayerPrefs.GetInt("conquestSemEstourar60");
        int semEstourar70 = PlayerPrefs.GetInt("conquestSemEstourar70");
        int semEstourar100 = PlayerPrefs.GetInt("conquestSemEstourar100");

        if (semEstourar10 < 10)
            PlayerPrefs.SetInt("conquestSemEstourar10", 0);

        if (semEstourar30 < 30)
            PlayerPrefs.SetInt("conquestSemEstourar30", 0);

        if (semEstourar50 < 50)
            PlayerPrefs.SetInt("conquestSemEstourar50", 0);

        if (semEstourar60 < 60)
            PlayerPrefs.SetInt("conquestSemEstourar60", 0);

        if (semEstourar70 < 70)
            PlayerPrefs.SetInt("conquestSemEstourar70", 0);

        if (semEstourar100 < 100)
            PlayerPrefs.SetInt("conquestSemEstourar100", 0);

    }
}
