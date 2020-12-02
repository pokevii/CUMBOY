using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Animator animator;
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return; 
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }


    //This method will not fade in, it will just straight up play a sound immediately. Good for SFX.
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning($"Sound {name} not found when calling PlaySound. Did you misspell it? Coming from {gameObject}");
            return;
        }
        s.source.volume = s.volume;
        s.source.Play();
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound {name} not found when calling StopSound. Did you misspell it? Coming from {gameObject}");
            return;
        }
        s.source.Stop();
        s.source.volume = s.volume;
    }

    //This method fades in using a coroutine.
    public void FadeIn(string name)
    {
        StartCoroutine(FadeInCoroutine (name));
    }

    //This method will fade out. 
    public void FadeOut(string name)
    {
        StartCoroutine(FadeOutCoroutine(name));
    }

    //Coroutines
    IEnumerator FadeOutCoroutine(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound {name} not found when calling FadeOut. Did you misspell it?");
            yield return null;

        }

        s.source.volume = s.volume;

        while (s.source.volume > 0)
        {
            s.source.volume -= 0.001f;
            yield return null;
        }
        s.source.Stop();
    }

    IEnumerator FadeInCoroutine(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound {name} not found when calling FadeOut. Did you misspell it?");
            yield return null;
        }

        s.volume = 0;
        s.source.Play();

        while (s.source.volume < s.volume)
        {
            s.source.volume += 0.001f;
            yield return null;
        }
    }
}



