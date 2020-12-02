using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class CompletionPercentage : MonoBehaviour
{
    public Text textDisplay;

    private GameManager gameManager;
    private double endingsMaximum;
    private double endingsCount;

    void Update()
    {
        gameManager = FindObjectOfType<GameManager>();

        endingsCount = gameManager.endingCount;
        endingsMaximum = 3.0;

        /*
        double completion = (endingsCount / endingsMaximum);
        completion *= 100;
        completion = Math.Round(completion, 2);
        */

        if(endingsCount > 0)
        {
            textDisplay.text = $"COMPLETION: {endingsCount}/{endingsMaximum}";
        }
        else if(endingsCount == endingsMaximum)
        {
            textDisplay.color = Color.green;
        }
        else
        {
            textDisplay.text = "";
        }

    }
}
