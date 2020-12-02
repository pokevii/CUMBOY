using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DialogueManager : MonoBehaviour
{
    public Text textDisplay;
    public GameObject continueButton;
    public GameObject fastForward;

    [TextArea(2, 4)] public string[] sentences;
    [HideInInspector] public int index;
    [Range(0.01f, 1f)] public float typeSpeed = 0.02f;
 
    public GameObject nextDialogue;

    private float speed;
    private bool fastMode;
    private AudioSource source;
    private string colorTag = "<color=#00000000>";

    private void Start()
    {
        fastForward.SetActive(false);
        source = GetComponent<AudioSource>();
        StartCoroutine(TypewriterEffect());
        speed = typeSpeed;
    }

    private void Update()
    {
        //Debug.Log($"Index < sentences.Length. || index: {index} length: {sentences.Length - 1}");
        if (textDisplay.text == sentences[index] + colorTag + "</color>")
        {
            if(Input.GetAxis("FFWD") == 1)
            {
                continueButton.SetActive(false);
                NextSentence();
            } else
            continueButton.SetActive(true); 
        }

        if (Input.GetAxis("Confirm") == -1)
        {
            {
                StopAllCoroutines();
                textDisplay.text = sentences[index] + colorTag + "</color>";
            }
        }

        #region Fast Forward Function
        /*
        if (Input.GetAxis("FFWD") == 1 && fastForward != null)
        {
            speed = typeSpeed / 2;
            fastMode = true;
            source.pitch = 2;
            source.volume = 0.3f;
            fastForward.SetActive(true);
        }
        else if (Input.GetAxis("FFWD") != 1 && fastForward != null)
        {
            fastMode = false;
            speed = typeSpeed;
            source.pitch = 1;
            source.volume = 0.694f;
            fastForward.SetActive(false);
        }
        */
        #endregion
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypewriterEffect());
        }
        else
        {

            Debug.Log($"advancing to {nextDialogue}");
            fastForward.SetActive(false);
            continueButton.SetActive(false);
            textDisplay.text = "";
            nextDialogue.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    /* IEnumerator Type()
    {
        //CalculateLengthOfMessage(sentences[index]);
        foreach(char letter in sentences[index].ToCharArray())
        {

            textDisplay.text += letter;
            yield return new WaitForSeconds(speed);

            if(fastMode == false)
            {
                if (letter == '.')
                {
                    yield return new WaitForSeconds(0.4f);
                }
                if (letter == ',')
                {
                    yield return new WaitForSeconds(0.2f);
                }
                if (letter == '\n')
                {
                    yield return null;
                }
            }

            if (letter != ' ')
            {
                source.Play();
            }
        }
    }
    */

    //Shoutouts to u/VeryConfusedOne for this solution, along with some others. Switching the color makes that shit wrap effect go away. Sick.
    IEnumerator TypewriterEffect()
    {
        int charIndex = 0;
        

        while(charIndex <= sentences[index].Length)
        {
            textDisplay.text = sentences[index].Substring(0, charIndex) + colorTag + sentences[index].Substring(charIndex) + "</color>";
            charIndex++;

            if(charIndex >= 2)
            {
                if (sentences[index][charIndex - 2] != ' ' && sentences[index][charIndex - 2] != '"')
                {
                    source.Play();
                }

                if (sentences[index][charIndex - 2] == '.' && fastMode == false)
                {
                    yield return new WaitForSeconds(0.4f);
                }

                if (sentences[index][charIndex - 2] == ',' && fastMode == false)
                {
                    yield return new WaitForSeconds(0.2f);
                }
            }   
            yield return new WaitForSeconds(speed);
        }
    }
}
