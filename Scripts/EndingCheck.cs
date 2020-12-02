using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCheck : MonoBehaviour
{
    public static EndingCheck instance;
    public static bool[] endingFlags;
    private GameManager gameManager;
    private Scene thisScene;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

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
    }

    void Start()
    {
        endingFlags = gameManager.endingFlags;
        thisScene = SceneManager.GetActiveScene();
        SceneManager.sceneLoaded += CheckSceneForEndings;
    }

    public void CheckSceneForEndings(Scene scene, LoadSceneMode mode)
    {
        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "BeachGameOver":
                GrantEnding(0);
                break;
            case "HouseGameOver1":
                GrantEnding(1);
                break;
            case "HouseGameOver2":
                GrantEnding(2);
                break;
            default:
                Debug.Log("switch case went to default.\n" + sceneName);
                break;

        }
    }

    private void GrantEnding(int flagNumber)
    {
        try
        {
            if (endingFlags[flagNumber] == false)
            {
                Debug.Log("Ending " + flagNumber + " has been granted.");
                gameManager.endingFlags[flagNumber] = true;
                gameManager.endingCount += 1;
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.Log(e);
        }
    }
}
