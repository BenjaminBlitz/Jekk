using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static readonly string VolumePref = "VolumePref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private float volumeFloat;
    private float soundEffectFloat;
    public AudioSource musicSource;
    public AudioSource[] soundEffectSource;
    public AudioClip Music1;
    bool isPlaying;
    bool isPaused;
    private float volume;

    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        volumeFloat = PlayerPrefs.GetFloat(VolumePref);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);

        musicSource.volume = volumeFloat;
        this.volume = volumeFloat;

        for (int i = 0; i < soundEffectSource.Length; i++)
        {
            soundEffectSource[i].volume = soundEffectFloat;
        }
    }

    void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = Music1;
        isPlaying = false;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuPause.GamePaused && !isPlaying)
        {
            musicSource.Play();
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
        musicSource.volume = this.volume;
        musicSource.Pause();
        musicSource.Play();
        //Debug.Log(musicSource.volume);
    }

    public void updateVolume(float volume)
    {
        this.volume = volume;
    }
}
