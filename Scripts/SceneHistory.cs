using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHistory : MonoBehaviour
{
    public List<string> sceneHistory;

    public void Start()
    {
        if(FindObjectOfType<GameManager>().sceneHistory == null)
        {
            sceneHistory = new List<string>();
        }
        else
        {
            sceneHistory = FindObjectOfType<GameManager>().sceneHistory;
        }
    }

    public void Update()
    {
        if(sceneHistory.Count >= 10)
        {
            sceneHistory.RemoveAt(0);
        }
    }

    public void LoadScene(string currentScene)
    {
        sceneHistory.Add(currentScene);
        Debug.Log(currentScene + " added to sceneHistory list.\n" +
            "sceneHistory count: " + sceneHistory.Count);

        SceneManager.LoadScene(currentScene);
    }

    public bool LoadPreviousScene()
    {
        bool returnValue = false;
        if (sceneHistory.Count >= 2)
        {
            returnValue = true;
            sceneHistory.RemoveAt(sceneHistory.Count - 1);
            SceneManager.LoadScene(sceneHistory[sceneHistory.Count - 1]);
        }

        return returnValue;
    }

}
