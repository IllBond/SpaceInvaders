using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Fleet _fleet;

    private void Awake()
    {
        _fleet = GetComponentInParent<Fleet>();
    }

    public void SwitchDirection()
    {
        _fleet.SwitchDirection();
    }

    public void CheckWin() {
        _fleet.CheckWin();
    }
}
