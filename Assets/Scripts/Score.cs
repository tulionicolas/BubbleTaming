using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class Score : MonoBehaviour
{
    public static float scoreLab = 10.0f;
	private static float scoreTotal;
    private Player player;    // Reference to the player control script.
	public Text uiScore;

	//public static void setScore(float value) { scoreTemp = value; }
	//public static float getScore() { return scoreTemp; }


    void Awake ()
    {
        // Setting up the reference.
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		//uiScore = GetComponent<Text>();

		scoreTotal = PlayerPrefs.GetFloat ("score");
		//PlayerPrefs.SetFloat ("scoreLab", 0);
    }


	void FixedUpdate ()
    {
		uiScore.text = scoreLab.ToString ("000");
    }

	public static void GravaScore()
	{
		string nameScore = PlayerPrefs.GetString ("labCurrent") + "Score";

		PlayerPrefs.SetFloat ("scoreLab", scoreLab);

		if (scoreLab > PlayerPrefs.GetFloat (nameScore)) {
			PlayerPrefs.SetFloat (nameScore, scoreLab);

			scoreTotal += scoreLab;
			PlayerPrefs.SetFloat ("score", scoreTotal);
			if (Social.localUser.authenticated) {
				Social.ReportScore ((int)scoreTotal, "CodigoGooglePlay", (bool sucesso) => {
				});
			}
		}
	}

}
