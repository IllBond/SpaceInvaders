using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreComponent : MonoBehaviour
{
    public int score;
    //[SerializeField] private Interface _interface;
    public int _bestScore;
    [SerializeField] private UnityEvent _changeScore;
    [SerializeField] private UnityEvent _changeBestScore;
    //private Interface _interface;
    private GameSession _session;

    private void Awake()
    {
        _session = FindObjectOfType<GameSession>();
        _bestScore = _session.Data.bestScore;
        score = _session.Data.score;
    }
    private void Start()
    {
        //_interface = FindObjectOfType<Interface>();
        _changeScore.Invoke();
        _changeBestScore.Invoke();
    }

    public void ResetScore()
    {
        score = 0;
        _session.Data.score = 0;
        _changeScore.Invoke();
    }

    public void AddScore() {
        score++;
        _session.Data.score++;

        _changeScore.Invoke();
        //_interface.SetCurrentScore();

        if (score > _bestScore)
        {
            
            //_interface.SetBestScore();
            _session.Data.bestScore = _session.Data.score;
            SaveManager.SaveData(gameObject);
            _changeBestScore.Invoke();
            
        }
    }





}
