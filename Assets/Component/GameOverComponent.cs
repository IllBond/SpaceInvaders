using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverComponent : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;
    //[SerializeField] private HealthComponent _player;
    

    public void GameOver() {
        _action.Invoke();
        //_player.ResetHealth();
    }
}
