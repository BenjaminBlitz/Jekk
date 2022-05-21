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
    }

    // Update is called once per frame
    void Update()
    {
        GameMusicStart.volume = volume;
        if (!MenuPause.GamePaused && !isPlaying)
        {
            GameMusicStart.Play();
            isPlaying = true;
        }
        if (MenuPause.GamePaused && isPlaying)
        {
            GameMusicStart.volume = 0.0f;
            isPaused = true;
        }
        if (!MenuPause.GamePaused && isPaused)
        {
            GameMusicStart.volume = 1.0f;
            isPaused = false;
        }
    }

    public void updateVolume(float volume)
    {
        this.volume = volume;
    }
}
