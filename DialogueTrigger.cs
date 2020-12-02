using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [HideInInspector] public DialogueManager dialogueManager;
    public int indexOfSentence;

    [Header("Animation Settings")]
    public Animator animator;
    public string animatorTriggerName;

    [Header("Music Settings")]
    public bool fadeIn;
    public string soundToPlay;
    public bool fadeOut;
    public string soundToStop;

    private void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
    }

    private void Update()
    {

        if (dialogueManager.index == indexOfSentence)
        {
            #region FadeIn / PlaySound
            if (soundToPlay != null || soundToPlay == "")
            {
                if (fadeIn)
                {
                    FindObjectOfType<AudioManager>().FadeIn(soundToPlay);
                }
                else
                {
                    FindObjectOfType<AudioManager>().PlaySound(soundToPlay);
                    indexOfSentence = -1;
                }
            }
            #endregion

            #region FadeOut / StopSound
            if (soundToStop != null || soundToStop == "")
            {
                if (fadeOut)
                {
                    FindObjectOfType<AudioManager>().FadeOut(soundToStop);
                }
                else
                {
                    FindObjectOfType<AudioManager>().StopSound(soundToStop);
                    indexOfSentence = -1;
                }
            }
            #endregion

            if (animator != null && animatorTriggerName != null)
            {
                animator.SetTrigger(animatorTriggerName);
            }
        }

        else
        {
            if(animator != null && animatorTriggerName != null)
            {
                animator.ResetTrigger(animatorTriggerName);
            }
        }    
    }
}
