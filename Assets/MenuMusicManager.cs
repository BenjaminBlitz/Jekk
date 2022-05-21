using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
    public AudioSource GameMusicStart;
    public AudioClip Music1;
    public static bool isInGame;
    // Start is called before the first frame update
    void Start()
    {
        isInGame = false;
        GameMusicStart = gameObject.AddComponent<AudioSource>();
        GameMusicStart.clip = Music1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameMusicStart.isPlaying && !isInGame) GameMusicStart.Play();
    }

    public void StopMusic()
    {
        GameMusicStart?.Stop();
        isInGame = true;
    }
}
