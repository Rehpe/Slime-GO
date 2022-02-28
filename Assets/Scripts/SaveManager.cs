using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;

public static class SaveManager
{
    public static void Save(GameData gameData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameData.bin";
        FileStream file = File.Create(path);

        bf.Serialize(file, gameData);
        file.Close();
    }



    public static GameData Load()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            string path = Application.persistentDataPath + "/gameData.bin";
            FileStream file = File.OpenRead(path);

            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            return data;

        }
        catch
        {
            Debug.LogError("Save file not exists");

            return null;
        }
    }
}