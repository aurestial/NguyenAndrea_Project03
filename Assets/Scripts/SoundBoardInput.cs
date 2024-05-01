using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoardInput : MonoBehaviour
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

    public static SoundBoardInput instance;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))

        {
            Play("Q");
        }

        if (Input.GetKeyDown(KeyCode.W))

        {
            Play("W");
        }

        if (Input.GetKeyDown(KeyCode.E))

        {
            Play("E");
        }

        if (Input.GetKeyDown(KeyCode.R))

        {
            Play("R");
        }

        if (Input.GetKeyDown(KeyCode.T))

        {
            Play("T");
        }

    }
}
