using SDD.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject m_MenuPanel;
    [SerializeField] GameObject m_PausePanel;
    [SerializeField] GameObject m_VictoryPanel;
    [SerializeField] GameObject m_GameOverPanel;

    List<GameObject> m_Panels = new List<GameObject>();

    void OpenPanel(GameObject panel)
    {
        m_Panels.ForEach(item => item.SetActive(item == panel));
    }

    void GameMenuEventCallback(GameMenuEvent e)
    {
        OpenPanel(m_MenuPanel);
    }
    void GamePlayEventCallback(GamePlayEvent e)
    {
        OpenPanel(null);
    }
    public void PlayButtonClicked()
    {
        EventManager.Instance.Raise(new PlayButtonClickedEvent());
    }

    private void OnEnable()
    {
        EventManager.Instance.AddListener<GameMenuEvent>(GameMenuEventCallback);
        EventManager.Instance.AddListener<GamePlayEvent>(GamePlayEventCallback);
    }

    private void OnDisable()
    {
        EventManager.Instance.RemoveListener<GameMenuEvent>(GameMenuEventCallback);
        EventManager.Instance.RemoveListener<GamePlayEvent>(GamePlayEventCallback);
    }
    private void Awake()
    {
        m_Panels.AddRange(new GameObject[] { m_MenuPanel, m_PausePanel, m_VictoryPanel, m_GameOverPanel });
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