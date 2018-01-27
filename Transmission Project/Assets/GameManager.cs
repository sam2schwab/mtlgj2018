using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public int TimeElapsed { get; private set; }

    //Awake is always called before any Start functions
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

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        TimeElapsed = 6;
        UpdateTimeDisplay();
    }

    private void UpdateTimeDisplay()
    {
        int jour = TimeElapsed / 24 + 1;
        int heure = TimeElapsed % 24;
        string timeDisplay = string.Format("Day {0}, {1}h00", jour, heure);
        FindObjectOfType<Canvas>().transform.Find("timeElapsed").gameObject.GetComponent<Text>().text = timeDisplay;
    }



    //Update is called every frame.
    void Update()
    {

    }

    public void AddTimeElapsed(int time)
    {
        TimeElapsed += time;
        UpdateTimeDisplay();
    }
}