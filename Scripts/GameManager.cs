using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int endingCount;
    public bool[] endingFlags;
    public List<string> sceneHistory;
    public string savedScene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        endingFlags = new bool[23];
        LoadData();

    }

    private void Update()
    {
        sceneHistory = FindObjectOfType<SceneHistory>().sceneHistory;
    }

    //Make SaveCurrentScene method

    public void SaveData()
    {
        SaveSystem.SaveData(this);
    }
    public void SaveCurrentScene()
    {
        savedScene = SceneManager.GetActiveScene().name;
        switch (savedScene)
        {
            case "BeachGameOver":
                savedScene = "BeachPart1";
                break;
            case "BeachSave":
                savedScene = "HousePart1";
                break;
            case "HouseGameOver1":
                savedScene = "HousePart1";
                break;
            case "HouseGameOver2":
                savedScene = "HousePart2";
                break;
            default:
                break;
        }
    }

    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadData();
        endingCount = data.endingsCompleted;
        savedScene = data.savedLevel;
        endingFlags = data.endingFlags;
        sceneHistory = data.history;
    }

    public void DeleteSaveData()
    {
        SaveSystem.DeleteSaveData();
    }

    public void LoadSavedScene()
    {
        if(savedScene != null)
        {
            FindObjectOfType<SceneHistory>().LoadScene(savedScene);
        }
        else
        {
            Debug.Log("No saved scene found.");
        }
    }
}
