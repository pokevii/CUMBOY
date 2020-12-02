using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveSystem
{
    public static void SaveData(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedata.cum";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(gameManager);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Save completed!");
    }

    public static PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/savedata.cum";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            try { }
            catch(Exception e)
            {
                Debug.LogError("Save file not found in " + path + "\n" + e);
            }

            return null;
        }

    }

    public static void DeleteSaveData()
    {
        string path = Application.persistentDataPath + "/savedata.cum";
        if(File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Save data deleted.");
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }

    }
}
