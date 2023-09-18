using UnityEngine;
using System.Collections;

public class Language : MonoBehaviour {

	public static string tapStart;

	public static string startGame;
	public static string options;
	public static string score;
	public static string tutorial;
	public static string credits;

	public static string creditsText;

	public static string music;
	public static string sounds;
	public static string language;
	public static string control;
	public static string resetSaved;


	// Use this for initialization
	public static void Carregar()
	{
		if (PlayerPrefs.GetInt ("language") == 1) {
			Language.Portugues ();
		} else {
			Language.English ();
		}
	}

	public static void English()
	{
		Language.tapStart = "GO";
		// -------------- Menu
		Language.startGame = "Start Game";
		Language.options = "Options";
		Language.score = "Score";
		Language.tutorial = "Tutorial";
		Language.credits = "Credits";

		Language.music = "Music";
		Language.sounds = "Sounds";
		Language.language = "Language";
		Language.control = "Control";
		Language.resetSaved = "Reset Saved";


		// ----- Credits
		Language.creditsText = "Game Design:\n" +
			"Flávia Tironi\n\n" +
			"Develop:\n" +
			"Túlio Nícolas N. Oliveira\n\n" +
			"Soundtrack:\n" +
			"Túlio Nícolas N. Oliveira\n\n" +
			"Tests:\n" +
			"Túlio Nícolas\n" +
			"\n\n" +
			"Thanks:\n" +
			"All MusicMonkey Team\n" +
			"Gessy Nogueira . The wisdom in difficult times\n" +
			"Vânia Nogueira . Who always asks about the games\n" +
			"Álvaro e Fátima . The unconditional support\n" +
			"and all the people who contributed in some \nway to this project\n\n\n" +
			"Thanks for playing Bubble Taming";

		// -------------- Pause


		// ------------------- Labirintos

	}

	public static void Portugues()
	{
		Language.tapStart = "GO";

		// -------------- Menu
		Language.startGame = "Iniciar Jogo";
		Language.options = "Opções";
		Language.score = "Pontuação";
		Language.tutorial = "Tutorial";
		Language.credits = "Créditos";

		Language.music = "Música";
		Language.sounds = "Sons";
		Language.language = "Linguagem";
		Language.control = "Controle";
		Language.resetSaved = "Limpar Dados";

		// ----- Credits
		Language.creditsText = "Game Design:\n" +
			"Flávia Tironi\n\n" +
			"Develop:\n" +
			"Túlio Nícolas N. Oliveira\n\n" +
			"Audio:\n" +
			"Túlio Nícolas Nogueira\n\n" +
			"Testes/Qualidade:\n" +
			"Túlio Nícolas\n" +
			"\n\n" +
			"Agradecimentos:\n" +
			"Todo o time MusicMonkey\n" +
			"Gessy Nogueira . Pela sabedoria nas horas difíceis\n" +
			"Vânia Nogueira . Que sempre pergunta sobre os games\n" +
			"Álvaro e Fátima . Pelo apoio incondicional\n" +
			"e todas as pessoas que contribuiram de alguma\nforma para este projeto\n\n\n" +
			"Obrigado por jogar Bubble Taming";
		

		// -------------- Pause
	}
}
