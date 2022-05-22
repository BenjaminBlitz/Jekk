using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay"; 
    private static readonly string VolumePref = "VolumePref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private int firstPlayInt;
    public Slider volumeSlider;
    public Slider soundEffectSlider;
    private float volumeFloat;
    private float soundEffectFloat;
    public AudioSource musicSource;
    public AudioSource[] soundEffectSource;
    public AudioClip Music1;
    public static bool isInGame;


    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        isInGame = false;
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = Music1;

        if (firstPlayInt == 0)
        {
            volumeFloat = 0.25f;
            soundEffectFloat = 0.5f;
            volumeSlider.value = volumeFloat;
            soundEffectSlider.value = soundEffectFloat;
            PlayerPrefs.SetFloat(VolumePref, volumeFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, soundEffectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            volumeFloat = PlayerPrefs.GetFloat(VolumePref);
            soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
            volumeSlider.value = volumeFloat;
            soundEffectSlider.value = soundEffectFloat;
        }
    }

    void Update()
    {
        if (!musicSource.isPlaying && !isInGame) musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
        isInGame = true;
    }
    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat (VolumePref, volumeSlider.value);
        PlayerPrefs.SetFloat (SoundEffectPref, soundEffectSlider.value);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSoundSetting();
        }
    }

    public void UpdateSound()
    {
        musicSource.volume = volumeSlider.value;
        for (int i = 0; i < soundEffectSource.Length; i++)
        {
            soundEffectSource[i].volume = soundEffectSlider.value;
        }
    }
}
