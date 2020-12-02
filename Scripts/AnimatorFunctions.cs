using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorFunctions : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    public bool disableOnce;

    void PlaySound(AudioClip whichSound)
    {
        if(!disableOnce)
        {
            menuButtonController.audioSource.PlayOneShot(whichSound);
        }
        else
        {
            disableOnce = false;
        }
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void EnableCanvas(Canvas canvas)
    {
        GetComponent<Canvas>().enabled = true;
    }

    public void LinkToTwitter()
    {
        Application.OpenURL("https://twitter.com/pokevii_");
    }

    #region Scene Functions
    void ChangeScene(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);

    }

    void ChangeSceneByString(string sceneToLoad)
    {
        FindObjectOfType<SceneHistory>().LoadScene(sceneToLoad);
    }

    void RefreshScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void LoadPreviousScene()
    {
        FindObjectOfType<SceneHistory>().LoadPreviousScene();
    }
    #endregion

    #region Dialogue Functions
    //Dialogue-related functions
    public void NextDialogue()
    {
        FindObjectOfType<DialogueManager>().NextSentence();
    }
    #endregion

    #region Audio Functions

    //Audio-related functions
    public void PlayNewAudio(string audioName)
    {
        FindObjectOfType<AudioManager>().PlaySound(audioName);
    }

    public void PlayNewSound(AudioClip audioClip)
    {
        FindObjectOfType<AudioSource>().PlayOneShot(audioClip);
    }

    public void FadeOutAudio(string audioName)
    {
        FindObjectOfType<AudioManager>().FadeOut(audioName);
    }

    public void FadeInAudio(string audioName)
    {
        FindObjectOfType<AudioManager>().FadeIn(audioName);
    }
    #endregion

    #region Save Functions
    void SaveData()
    {
        FindObjectOfType<GameManager>().SaveData();
    }

    void SaveCurrentScene()
    {
        FindObjectOfType<GameManager>().SaveCurrentScene();
    }

    void LoadData()
    {
        FindObjectOfType<GameManager>().LoadData();
    }

    void LoadSavedScene()
    {
        FindObjectOfType<GameManager>().LoadSavedScene();
    }

    void DeleteSaveData()
    {
        FindObjectOfType<GameManager>().DeleteSaveData();
    }
    #endregion
}
