using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrack : MonoBehaviour {

    public AudioClip[] backgroundMusic;
    public AudioSource audioSourceMusic;
    public static bool music;
    public static bool sounds;

    public bool level = true;

    private static SoundTrack instance = null;
    public static SoundTrack Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        music = (PlayerPrefs.GetInt("music") == 1 ? true : false);
        sounds = (PlayerPrefs.GetInt("sounds") == 1 ? true : false);

        audioSourceMusic = GetComponent<AudioSource>();


        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        if (level) DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (!audioSourceMusic.isPlaying && music)
            execMusic();

        if (!music)
            audioSourceMusic.Stop();
    }


    public void execMusic()
    {
        int i = Random.Range(0, backgroundMusic.Length);

        audioSourceMusic.playOnAwake = true;
        audioSourceMusic.loop = true;
        audioSourceMusic.PlayOneShot(backgroundMusic[i]);
    }
}
