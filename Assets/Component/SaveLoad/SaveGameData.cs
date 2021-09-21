using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGameData
{
    [Header("Игрок")]
    public int score;
    public int bestScore;
    public int healthPlayer;
    [Header("Цвет корабля")]
    public ColorRGB playerColor;
    [Header("Флот")]
    public float speedFleet;
    public float _fallSpeedFleet;

    public SaveGameData(GameObject player) {
        bestScore = player.GetComponent<ScoreComponent>().score;
        playerColor.r = player.GetComponent<ColorComponent>()._sr.color.r;
        playerColor.g = player.GetComponent<ColorComponent>()._sr.color.g;
        playerColor.b = player.GetComponent<ColorComponent>()._sr.color.b;
    }

    [System.Serializable]
    public struct ColorRGB {
        public float r, g, b;
        public ColorRGB(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }

}


