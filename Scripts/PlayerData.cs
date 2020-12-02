using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string savedLevel;
    public int endingsCompleted;
    public List<string> history;
    public bool[] endingFlags;

    public PlayerData(GameManager gameManager)
    {
        savedLevel = gameManager.savedScene;
        endingsCompleted = gameManager.endingCount;
        history = gameManager.sceneHistory;
        endingFlags = gameManager.endingFlags;
    }
}
