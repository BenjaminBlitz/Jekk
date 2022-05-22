using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public PlayerManagement player;
    public TextMeshProUGUI Score;
    // Start is called before the first frame update
    void Start()
    {
        Score.text = "Score : " + player.score.ToString();
    }
}
