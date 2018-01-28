using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    private GameObject dataModel;

    public TavernOnMap tavernPrefab;

    private List<TavernOnMap> taverns;

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public int TimeElapsed { get; private set; }
    public TavernOnMap currentTavern;

    //to save state
    public Dictionary<int,List<Hero>> tavernHeroes;
    public Dictionary<int, bool> tavernRevealed;
    public Vector3 posHerald;

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

    internal void EnterTavern(Selectable tavern)
    {
        AddTimeElapsed(tavern.Cost);
        currentTavern = tavern.GetComponent<TavernOnMap>();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        tavernRevealed = new Dictionary<int, bool>();
        tavernHeroes = new Dictionary<int, List<Hero>>();

        dataModel = GameObject.Find("DataModal");
        dataModel.GetComponent<DataModal>().Load();
        TimeElapsed = 6;
        UpdateTimeDisplay();
        var tavernData = dataModel.GetComponent<DataModal>().TavernData;
        foreach (var data in tavernData)
        {
            var tavern = Instantiate(tavernPrefab);
            tavern.types = data.Heroes.ToArray();
            tavern.averageLevel = data.AveragePowerLevel;
            tavern.transform.position = new Vector3((float)data.PosX, (float)data.PosY, 0);
            tavern.id = data.TavernID;
        }
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

    public void SaveStateOfMap()
    {
        tavernHeroes = new Dictionary<int, List<Hero>>();
        tavernRevealed = new Dictionary<int, bool>();
        posHerald = FindObjectOfType<MovingPlayer>().transform.position;
        TavernOnMap[] tavernOnMap = FindObjectsOfType<TavernOnMap>();
        foreach (var tav in tavernOnMap)
        {
            tavernRevealed.Add(tav.id, tav.Revealed);
            tavernHeroes.Add(tav.id, tav.heroes);
        }
    }

    public void LoadStateOfMap()
    {
        UpdateTimeDisplay();
        FindObjectOfType<MovingPlayer>().transform.position = posHerald;
        var tavernData = dataModel.GetComponent<DataModal>().TavernData;
        for (int i = 0; i < tavernData.Count; i++)
        {
            var data = tavernData[i];
            var tavern = Instantiate(tavernPrefab);
            tavern.types = data.Heroes.ToArray();
            tavern.averageLevel = data.AveragePowerLevel;
            tavern.transform.position = new Vector3((float)data.PosX, (float)data.PosY, 0);
            tavern.heroes = tavernHeroes[tavernData[i].TavernID];
            tavern.Revealed = tavernRevealed[tavernData[i].TavernID];
            tavern.id = data.TavernID;
        }
    }
}