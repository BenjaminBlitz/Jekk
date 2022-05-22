using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private float soundEffectFloat;
    public AudioSource GameSound;
    public AudioClip Sound;
    bool isPlaying;

    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
        GameSound.volume = soundEffectFloat;
    }

    void Start()
    {
        GameSound = gameObject.AddComponent<AudioSource>();
        GameSound.clip = Sound;
        isPlaying = false;
        ContinueSettings();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameSound.volume);
        //Debug.Log(soundEffectFloat);
        //ContinueSettings();
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
