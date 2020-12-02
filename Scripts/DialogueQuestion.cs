using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueQuestion : MonoBehaviour
{
    public Text textDisplay;
    [TextArea(2, 4)] public string question;
    [Range(0.01f, 1f)] public float typeSpeed = 0.02f;

    [Header("Question Properties")]
    public string[] options;
    public Text[] optionDisplay;
    public Animator[] optionAnimator;
    public string[] nextScene;

    public GameObject mainScreen;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(Type());
        mainScreen.GetComponent<MenuButtonController>().maxIndex = options.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        //If the question text is loaded, enable both of the options, and check if the button is pressed to go to the next scene.
        //running a for loop once per frame doesnt seem very smart..
        if(textDisplay.text == question)
        {
            mainScreen.GetComponent<MenuButtonController>().enabled = true;
            mainScreen.GetComponentInChildren<MenuButton>().enabled = true;

            for (int i = 0; i < optionDisplay.Length; i++)
            {
                optionDisplay[i].text = options[i]; 
                optionDisplay[i].enabled = true;
                if (optionAnimator[i].GetBool("pressed"))
                {
                    StartCoroutine(LoadNextScene(nextScene[i]));
                }
            }
        }
    }

    IEnumerator LoadNextScene(string nextScene)
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<SceneHistory>().LoadScene(nextScene);
    }

    IEnumerator Type()
    {
        foreach (char letter in question.ToCharArray())
        {

            if (letter != ' ')
            {
                source.Play();
            }

            textDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);

            if (letter == '.')
            {
                yield return new WaitForSeconds(0.4f);
            }
            if (letter == ',')
            {
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
