using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] public int health;

    [SerializeField] private UnityEvent _OnChangeDamage;
    [SerializeField] private UnityEvent _OnChangeHeal;
    [SerializeField] private UnityEvent _OnDie;
    private GameSession _session;

    private void Awake()
    {
        _session = FindObjectOfType<GameSession>();
    }
    public void HealthChange(bool isDamage)
    {
        if (health <= 0) return;

        if (isDamage)
        {
            health --;   
            _OnChangeDamage?.Invoke();

            if (health <= 0)
            {
                _OnDie?.Invoke();
            }
        }
        else
        {
            health ++;
            _OnChangeHeal?.Invoke();
        }

    }

   
    public void Damage()
    {
        HealthChange(true);
    }

    public void Heal()
    {
        HealthChange(false);
    }

    public void DamagePlayer()
    {
        _session.Data.healthPlayer--;
    }
    public void HealPlayer()
    {
        _session.Data.healthPlayer++;
    }

    public void ResetHealth()
    {
        _session.Data.healthPlayer = 3;
    }

}
