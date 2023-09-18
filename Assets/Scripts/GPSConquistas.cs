using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class GPSConquistas : MonoBehaviour
{

	// Use this for initialization
	void Start () {

	}

	private void Validar () {
		if (Social.localUser.authenticated) {
			int qtdFim = PlayerPrefs.GetInt ("qtdFim");

			if (qtdFim <= 1) {
				float porcentagem = qtdFim * 100f;
				Social.ReportProgress ("CodigoScoreGooglePlay", porcentagem, (bool sucesso) => {
				});
			}

			if (qtdFim <= 10) {
				float porcentagem = qtdFim * 10f;
				Social.ReportProgress ("CodigoScoreGooglePlay", porcentagem, (bool sucesso) => {
				});
			}

			if (qtdFim <= 50) {
				float porcentagem = qtdFim * 2f;
				Social.ReportProgress ("CodigoScoreGooglePlay", porcentagem, (bool sucesso) => {
				});
			}

			if (qtdFim <= 100) {
				float porcentagem = qtdFim * 1f;
				Social.ReportProgress ("CodigoScoreGooglePlay", porcentagem, (bool sucesso) => {
				});
			}

			if (qtdFim <= 1000) {
				float porcentagem = qtdFim * 0.1f;
				Social.ReportProgress ("CodigoScoreGooglePlay", porcentagem, (bool sucesso) => {
				});
			}
		}
	}
}
