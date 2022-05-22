using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSoundEffectAudioSettings : MonoBehaviour
{
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private float soundEffectFloat;
    public AudioSource FireSource;
    public AudioClip FireSound;
    public AudioSource HitSource;
    public AudioClip HitSound;
    public AudioSource WalkSource;
    public AudioClip WalkSound;
    bool isPlaying;

    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
        FireSource.volume = soundEffectFloat;
        HitSource.volume = soundEffectFloat;
        WalkSource.volume = soundEffectFloat;
    }

    void Start()
    {
        FireSource = gameObject.AddComponent<AudioSource>();
        HitSource = gameObject.AddComponent<AudioSource>();
        WalkSource = gameObject.AddComponent<AudioSource>();
        FireSource.clip = FireSound;
        HitSource.clip = HitSound;
        WalkSource.clip = WalkSound;
        isPlaying = false;
        ContinueSettings();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameSound.volume);
        //Debug.Log(soundEffectFloat);
        //ContinueSettings();
        if (!MenuPause.GamePaused && PlayerManagement.hasFired)
        {
            FireSource.Play();
            //isPlaying = true;
        }
        if (!MenuPause.GamePaused && BulletManager.hasHit)
        {
            HitSource.Play();
            //isPlaying = false;
        }
        if (!MenuPause.GamePaused)
        {

        }
    }
}
