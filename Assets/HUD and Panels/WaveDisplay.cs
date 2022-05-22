using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveDisplay : MonoBehaviour
{
    public TextMeshProUGUI Wave;
    // Start is called before the first frame update
    public void CreateWave(int wave)
    {
        Wave.text = wave.ToString();
    }
}
