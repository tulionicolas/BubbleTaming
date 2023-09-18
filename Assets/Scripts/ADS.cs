using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADS : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (Advertisement.IsReady())
        {
            exibirAnuncio();
        }
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (!Advertisement.isShowing)
        {
            print("Run");
        }
	}

    public void exibirAnuncio()
    {
        Advertisement.Show();
    }
}
