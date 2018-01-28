using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSoundsManager : MonoBehaviour {

    public AudioClip TrumpetClip;
    public AudioClip TrumpetClipVictory;
    public AudioClip TrumpetClipFail;

    public static ScriptSoundsManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    // Use this for initialization
    void Start()
    {

    }

    public void PlayTrumpet()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = TrumpetClip;
        audio.Play();
    }

    public void PlayTrumpetVictory()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = TrumpetClipVictory;
        audio.Play();
    }
    public void PlayTrumpetFail()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = TrumpetClipFail;
        audio.Play();
    }
    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
}
