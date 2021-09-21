using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireComponent : MonoBehaviour
{
    [SerializeField] private BulletComponent _bullet;
    [SerializeField] private Transform _pointFire;
    [SerializeField] private float _fireRate = 1; 
    [SerializeField] private float _bulletSpeed = 1; 
    
    private float _timer;
    private Vector2 _direction;

    private void Start()
    {
        _direction = _pointFire.position - transform.position;
    }

    [ContextMenu("Fire")]
    public void Fire() {
        if (CanFire()) {
            _timer = Time.time + _fireRate;
            BulletComponent bullet = Instantiate(_bullet, _pointFire.position, Quaternion.identity);
            bullet.BuletSpeed = _bulletSpeed;
            bullet.SetDirection(_direction);

        }
    }

    public bool CanFire()
    {
        return Time.time > _timer;
    }
}
