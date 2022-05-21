using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource GameMusicStart;
    public AudioClip Music1;
    bool isPlaying;
    bool isPaused;
    private float volume;
   
    // Start is called before the first frame update
    void Start()
    {
        GameMusicStart = gameObject.AddComponent<AudioSource>();
        GameMusicStart.clip = Music1;
        isPlaying = false;
        isPaused = false;
        this.volume = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuPause.GamePaused && !isPlaying)
        {
            GameMusicStart.Play();
            isPlaying = true;
        }
        if (MenuPause.GamePaused && isPlaying && !isPaused)
        {
            this.volume /= 10.0f;
            isPaused = true;
            //Debug.Log("en pause :" + this.volume);

        }
        if (!MenuPause.GamePaused && isPaused)
        {
            this.volume *= 10.0f;
            isPaused = false;
            //Debug.Log("hors pause :" + this.volume);

        }
        GameMusicStart.volume = this.volume;
        GameMusicStart.Pause();
        GameMusicStart.Play();
        //Debug.Log(GameMusicStart.volume);
    }

    public void updateVolume(float volume)
    {
        this.volume = volume;
    }
}
