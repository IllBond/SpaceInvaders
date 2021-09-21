using UnityEngine;
using static SaveGameData;

public class GameSession : MonoBehaviour
{
    [SerializeField] private SaveGameData _data;
    public SaveGameData Data => _data;

    private void Awake()
    {
        if (IsSessionExit())
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
            SetDataFromSave();
        }
    }

    private bool IsSessionExit()
    {
        var session = FindObjectsOfType<GameSession>();
        foreach (var gameSession in session)
        {
            if (gameSession != this)
            {
                return true;
            }
        }
        return false;
    }

    private void SetDataFromSave() {
        SaveGameData data = SaveManager.LoadData();
        if (data == null) return;
        _data.bestScore = data.bestScore;
        _data.playerColor = new ColorRGB(data.playerColor.r, data.playerColor.g, data.playerColor.b);
    }
}