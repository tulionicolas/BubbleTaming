using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectCamera : MonoBehaviour {
	#region Pola
	private int ScreenSizeX = 0;
	private int ScreenSizeY = 0;
	#endregion

	#region metody

	#region rescale camera
	private void RescaleCamera()
	{
		if (Screen.width == ScreenSizeX && Screen.height == ScreenSizeY) return;

        // Tamanho minimo e maximo sem afetar o aspect da camera
        float targetAspectMin = 16.0f / 9.0f; // Apos o tamanho minimo será inserido barras abaixo e acima da tela
        float targetAspectMax = 19.0f / 9.0f; // Apos o tamanho maximo será inserido barras á direita e á esquerda da tela


		float windowaspect = (float)Screen.width / (float)Screen.height;


		float scaleHeightMin = windowaspect / targetAspectMin;
        float scaleHeightMax = windowaspect / targetAspectMax;

        Camera camera = GetComponent<Camera>();

		if (scaleHeightMin < 1.0f)
		{
			Rect rect = camera.rect;

			rect.width = 1.0f;
			rect.height = scaleHeightMin;
			rect.x = 0;
			rect.y = (1.0f - scaleHeightMin) / 2.0f;

			camera.rect = rect;
		}
	    else if (scaleHeightMax > 1.0f) // add pillarbox
		{
			float scalewidth = 1.0f / scaleHeightMax;

			Rect rect = camera.rect;

			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;

			camera.rect = rect;
		}

		ScreenSizeX = Screen.width;
		ScreenSizeY = Screen.height;
	}
	#endregion

	#endregion

	#region metody unity

	void OnPreCull()
	{
		if (Application.isEditor) return;
		Rect wp = Camera.main.rect;
		Rect nr = new Rect(0, 0, 1, 1);

		Camera.main.rect = nr;
		GL.Clear(true, true, Color.black);

		Camera.main.rect = wp;

	}

	// Use this for initialization
	void Start () {
		RescaleCamera();
	}

	// Update is called once per frame
	void Update () {
		RescaleCamera();
	}
	#endregion
}
