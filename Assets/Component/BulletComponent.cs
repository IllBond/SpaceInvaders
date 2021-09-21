using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _lifeTime = 5;

    public float BuletSpeed { get; set; }

    [SerializeField] public Vector2 _direction = new Vector2(0,0);

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke("DestroyBulet", _lifeTime);
    }

    void FixedUpdate()
    {
        _rb.velocity = _direction * _speed * BuletSpeed;
    }

    public void SetDirection(Vector2 dir) {
        if (dir.y > 0) {
            _direction = Vector2.up;
        } else if (dir.y < 0) {
            _direction = Vector2.down;
        } else {
            _direction = Vector2.zero;
        }
    }

    public void DestroyBulet() {
        Destroy(gameObject);
    }
}
