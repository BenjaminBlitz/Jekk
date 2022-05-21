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
        GameMusicStart.volume = this.volume;
        if (!MenuPause.GamePaused && !isPlaying)
        {
            GameMusicStart.Play();
            isPlaying = true;
        }
        if (MenuPause.GamePaused && isPlaying)
        {
            this.volume = 0.2f;
            GameMusicStart.Pause();
            GameMusicStart.Play();
            isPaused = true;
        }
        if (!MenuPause.GamePaused && isPaused)
        {
            this.volume = 1.0f;
            GameMusicStart.Pause();
            GameMusicStart.Play();
            isPaused = false;
        }
        GameMusicStart.volume = this.volume;
    }

    public void updateVolume(float volume)
    {
        this.volume = volume;
    }
}
