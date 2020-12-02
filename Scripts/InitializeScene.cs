using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeScene : MonoBehaviour
{
    public GameObject MainScreen;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += DisableOptionsMenu;
    }

    void DisableOptionsMenu(Scene scene, LoadSceneMode mode)
    {
        try
        {
            MainScreen.GetComponent<MenuButtonController>().enabled = false;
            MainScreen.GetComponentInChildren<MenuButton>().enabled = false;
        }
        catch (UnassignedReferenceException e)
        {
            Debug.Log("You haven't assigned a MainScreen to InitializeScene just in case you wanted to.\n" + e);
        }
    }
}
