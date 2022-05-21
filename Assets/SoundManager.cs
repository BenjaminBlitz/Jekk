using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource GameMusicStart;
    public AudioClip Music1;
    bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        GameMusicStart = gameObject.AddComponent<AudioSource>();
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!MenuPause.GamePaused && !isPlaying)
        {
            GameMusicStart.PlayOneShot(Music1);
            isPlaying = true;
        }
        if (MenuPause.GamePaused && isPlaying)
        {
            GameMusicStart.Pause();
            isPlaying = false;
        }
    }
}
