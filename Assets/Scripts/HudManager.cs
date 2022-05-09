using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SDD.Events;
public class HudManager : MonoBehaviour
{
    [SerializeField] Text m_ScoreValueText;
    [SerializeField] Text m_TimeValueText;

    void SetScoreValueText(int score)
    {
        m_ScoreValueText.text = score.ToString();
    }
    void SetTimeValueText(float time)
    {
        m_TimeValueText.text = time.ToString("N01");
    }

    void GameStatisticsChangedEventCallBack(GameStatisticsChangedEvent e)
    {
        SetScoreValueText(e.eScore);
        SetTimeValueText(e.eCountdown);
    }
    private void OnEnable()
    {
        EventManager.Instance.AddListener<GameStatisticsChangedEvent>(GameStatisticsChangedEventCallBack);
    }
    private void OnDisable()
    {
        EventManager.Instance.RemoveListener<GameStatisticsChangedEvent>(GameStatisticsChangedEventCallBack);
    }

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
