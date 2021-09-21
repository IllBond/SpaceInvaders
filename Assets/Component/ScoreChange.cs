using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChange : MonoBehaviour
{
    private ScoreComponent _player;


    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<ScoreComponent>();
    }

    public void ChangeScore() {
        _player.AddScore();
        
    }
}
