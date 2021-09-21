using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveGameData;

public class ColorComponent : MonoBehaviour
{

    public SpriteRenderer _sr;
    private GameSession _session;

    private void Awake()
    {
        _session = FindObjectOfType<GameSession>();
        _sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        SetColor();
    }

    public void SetColor() {
        _sr.color = new Color(
            _session.Data.playerColor.r, 
            _session.Data.playerColor.g, 
            _session.Data.playerColor.b);
    }

    public void SetColorFromPalet(Color color){
        _sr.color = color;
        _session.Data.playerColor.r = color.r;
        _session.Data.playerColor.g = color.g;
        _session.Data.playerColor.b = color.b;
        SaveColor();
    }

    public void SaveColor() {
        SaveManager.SaveData(gameObject);
    }
}
