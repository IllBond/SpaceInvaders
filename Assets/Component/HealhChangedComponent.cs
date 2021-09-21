using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealhChangedComponent : MonoBehaviour
{
    [SerializeField] private bool isDamage;
 
    public void ChangeHealth(GameObject target)
    {
        var healthComponent = target.GetComponent<HealthComponent>();

        if (healthComponent != null)
        {
            if (isDamage) {
                healthComponent.Damage();
     
            } else {
                healthComponent.Heal();
            }
        }
    }
}
