using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audiomanager : MonoBehaviour
{
    public Sound[] sounds;

    public static Audiomanager dontrestartSound;

    public void Awake()
    {
        //Musik stopt nicht beim Scenenwechseln
        if (dontrestartSound == null)
        {
            dontrestartSound = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("backgroundmusic");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }

    public void Click()
    {
        Play("click");
    }

    public void Muteall()
    {
        AudioListener.pause = !AudioListener.pause;
    }


}
