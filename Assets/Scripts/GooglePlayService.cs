using UnityEngine;
using System.Collections;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;


public class GooglePlayService : MonoBehaviour
{
	public Button btnLogin;
	public Button btnRanking;
	public Button btnConquest;

	// Use this for initialization
	void Start ()
	{
        //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
		//PlayGamesPlatform.InitializeInstance(config);
		//PlayGamesPlatform.DebugLogEnabled = true;
		//PlayGamesPlatform.Activate();

		LoginGoogle();
		//Authenticated();
	}

	void FixedUpdate()
	{
		Authenticated ();
	}

	public void LoginGoogle()
	{
        Social.localUser.Authenticate((bool success) => {
            if (success) {
				Authenticated();

                float scoreTotal = PlayerPrefs.GetFloat("score");
                EnviarRanking((int)scoreTotal);
			}
		});
	}

	private void Authenticated()
	{
		if (Social.localUser.authenticated) {
			btnLogin.interactable = false;
			//btnRanking.interactable = true;
			//btnConquest.interactable = true;
		} else {
			btnLogin.interactable = true;
			//btnRanking.interactable = false;
			//btnConquest.interactable = false;
		}
	}

	public void ExibirRanking()
	{
		//PlayGamesPlatform.Instance.ShowLeaderboardUI ();
	}

	public void ExibirRanking(string idRanking)
	{
		//PlayGamesPlatform.Instance.ShowLeaderboardUI (idRanking);
        //CgkI6OmmwbgZEAIQAQ << Ranking
	}

	public void ExibirConquest()
	{
		Social.ShowAchievementsUI ();
	}

	public void EnviarRanking(string idRanking, int score)
	{
		Social.ReportScore (score, idRanking, (bool sucesso) => {
		});
	}

    public void EnviarRanking(int score)
    {
        //ID Ranking
        Social.ReportScore(score, "CgkI6OmmwbgZEAIQAQ", (bool sucesso) => {
        });
    }
}
