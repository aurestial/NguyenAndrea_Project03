using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundboard : MonoBehaviour
{
    public Sound[] sounds;

    public static Sound sound;



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
            s._source = gameObject.AddComponent<AudioSource>();

            s._source.clip = s._clip;

            s._source.volume = s._volume;

            s._source.pitch = s._pitch;

            s._source.loop = s._loop;
        }

    }

    public static Soundboard instance;

    public void Play(string _name)
    {
        Sound s = Array.Find(sounds, sound => sound._name == _name);

        if (s == null)
        {
            Debug.LogWarning("There is no sound called" + _name + "that exists");

            Debug.Log("Check your spelling ");


            return;


        }


        s._source.Play();



    }

    void Start()
    {
        Play("StartUp");

    }
}
