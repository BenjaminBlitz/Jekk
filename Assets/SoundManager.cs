using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource GameSound;
    public AudioClip Sound;
    bool isPlaying;
    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        GameSound = gameObject.AddComponent<AudioSource>();
        GameSound.clip = Sound;
        isPlaying = false;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuPause.GamePaused && !isPlaying)
        {
            GameSound.Play();
            isPlaying = true;
        }
        if (MenuPause.GamePaused && isPlaying)
        {
            GameSound.Pause();
            isPlaying = false;
        }
    }
}
