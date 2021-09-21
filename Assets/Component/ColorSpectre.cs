using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSpectre : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _palet;
    [SerializeField] private ColorComponent _player;

    public void SetColor() {
        _player.SetColorFromPalet(_palet.color);
    }
}
