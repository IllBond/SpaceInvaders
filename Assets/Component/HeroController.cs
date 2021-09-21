using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveGameData;

public class HeroController : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private float _speed = 15;
    
    [Header("Компоненты")]
    private Rigidbody2D _rb;
    private FireComponent _fireComponent;
    private HealthComponent _healthComponent;
    private GameSession _session;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _fireComponent = GetComponent<FireComponent>();
        _healthComponent = GetComponent<HealthComponent>();
        _session = FindObjectOfType<GameSession>();
    }


    private void Start()
    {
        _healthComponent.health = _session.Data.healthPlayer;
    }

    private void FixedUpdate()
    {
        var xVelocity = _direction.x * _speed;
        _rb.velocity = new Vector2(xVelocity, 0);
    }   
    
    public void Fire()
    {
        _fireComponent.Fire();
    }

    public void SavePlayer()
    {
        SaveManager.SaveData(gameObject);
    }

}
