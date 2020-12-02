using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    SceneHistory sceneHistory;
    public string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManager = GameObject.Find("GameManager");

        sceneHistory = gameManager.GetComponent<SceneHistory>();
        sceneHistory.LoadScene(sceneToLoad);
       
    }
}
