using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject deathMenuUI;
    public GameObject winMenuUI;
    public static bool isDead = false;
    public static bool hasWon = false;

    private void Awake()
    {
        isDead = false;
        hasWon = false;
        deathMenuUI.SetActive(false);
        winMenuUI.SetActive(false);
    }

    void Update()
    {
        if (isDead)
        {
            Lose();
        }

        else if (hasWon)
        {
            Win();
        }
    }

    public void Lose()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        MenuPause.GamePaused = true;
    }

    public void Win()
    {
        winMenuUI.SetActive(true);
        Time.timeScale = 0f;
        MenuPause.GamePaused = true;
    }

}
