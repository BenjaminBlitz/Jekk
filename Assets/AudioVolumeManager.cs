using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay"; 
    private static readonly string VolumePref = "VolumePref";
    private int firstPlayInt;
    public Slider volumeSlider;
    private float volumeFloat;
    public AudioSource musicSource;
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
            volumeSlider.value = volumeFloat;
            PlayerPrefs.SetFloat(VolumePref, volumeFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            volumeFloat = PlayerPrefs.GetFloat(VolumePref);
            volumeSlider.value = volumeFloat;
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
    }
}
