using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainScore : IScore
{
    [SerializeField] int m_Score;
    public int Score => m_Score;
}
