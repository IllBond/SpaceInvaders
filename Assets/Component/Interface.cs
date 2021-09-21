using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [SerializeField] private Text _health;
    [SerializeField] private Text _score;
    [SerializeField] private Text _bestScore;
    /*    [SerializeField] private HealthComponent _playerHealth;
        [SerializeField] private ScoreComponent _playerScore;*/
    private GameSession _session;

    private void Awake()
    {
        _session = FindObjectOfType<GameSession>();
    }

    private void Start()
    {
        SetCurrentHealth();
        //_bestScore.text = ""+PlayerPrefs.GetInt("bestScore");
    }

    public void SetCurrentHealth() {
        _health.text = "" + _session.Data.healthPlayer;
    }    
    
    public void SetCurrentScore() {
        
        _score.text = "" + _session.Data.score;
    }    
    
    public void SetBestScore() {
        if (_session.Data.score > _session.Data.bestScore) {
            _bestScore.text = "" + _session.Data.score;
        } else {
             _bestScore.text = "" + _session.Data.bestScore;
        } 
        
    }
}
