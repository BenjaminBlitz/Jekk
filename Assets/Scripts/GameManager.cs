using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;
enum GAMESTATE { menu, play, pause, victory, gameover }
public class GameManager : MonoBehaviour
{
    private static GameManager m_Instance;
    public static GameManager Instance { get { return m_Instance; } }
    GAMESTATE m_State;

    public bool IsPlaying { get { return m_State == GAMESTATE.play; } }
    private int m_Score;

    void SetScore(int newScore)
    {
        m_Score = newScore;
        EventManager.Instance.Raise(new GameStatisticsChangedEvent(){eScore=m_Score});
    }
    void SetState(GAMESTATE newSTtate)
    {   
        m_State = newSTtate;
        switch (m_State)
        {
            case GAMESTATE.menu:
                EventManager.Instance.Raise(new GameMenuEvent());
                break;
            case GAMESTATE.play:
                EventManager.Instance.Raise(new GamePlayEvent());
                break;
            case GAMESTATE.pause:
                EventManager.Instance.Raise(new GamePauseEvent());
                break;
            case GAMESTATE.victory:
                break;
            case GAMESTATE.gameover:
                break;
            default:
                break;
        }
       
        

    }

    void Menu()
    {
        SetState(GAMESTATE.menu);
        Time.timeScale = 0;
    }
    private void Play()
    {
        SetState(GAMESTATE.play);
        Time.timeScale = 1;
    }
    void PlayButtonClickedEventCallback(PlayButtonClickedEvent e)
    {
        Play();
    }
    private void OnEnable()
    {
        EventManager.Instance.AddListener<PlayButtonClickedEvent>(PlayButtonClickedEventCallback);
    }
    private void OnDisable()
    {
        EventManager.Instance.RemoveListener<PlayButtonClickedEvent>(PlayButtonClickedEventCallback);
    }
    private void Awake()
    {
        if (!m_Instance) m_Instance = this;
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Menu();
    }

    // Update is called once per frame
    void Update()
    {

    }
}