using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager    
{
    public static void SaveData(GameObject player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/save.gamesave";
        FileStream stream = new FileStream(filePath, FileMode.Create);

        SaveGameData data = new SaveGameData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static SaveGameData LoadData() {
        string filePath = Application.persistentDataPath + "/save.gamesave";
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            SaveGameData data = formatter.Deserialize(stream) as SaveGameData;
            stream.Close();

            return data;
        }
        else {
            Debug.LogWarning("Нет файла для следующего пути пока не существует: " + filePath);
            return null;
        }
    }

}
