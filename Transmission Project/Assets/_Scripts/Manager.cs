﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int resources;
    public int startingResources = 3;
    public Text text;
    public GameObject[] quests;
    private List<DataModal.Quest> questsData;
    // Use this for initialization

    void Start()
    {
        questsData = FindObjectOfType<TransmissionManager>().activeQuests;
        foreach (GameObject item in quests)
        {
            item.SetActive(false);
        }
        for (int i = 0; i < questsData.Count; i++)
        {
            quests[i].SetActive(true);
            quests[i].GetComponent<Quests>().types = questsData[i].HeroesRequired;
            quests[i].GetComponent<Quests>().UpdateIcons();
            quests[i].GetComponent<Quests>().difficulty = questsData[i].RequiredLevel;
            quests[i].GetComponent<Quests>().questObj = questsData[i];
            quests[i].GetComponent<Quests>().init();
            resources = startingResources;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool ValidateCost(int cost)
    {
        return cost <= resources;
    }
    public void PayCost(int cost)
    {
        resources = resources - cost;
        text.text = resources.ToString() + " / " + startingResources.ToString();
    }
    public void ExitToMap()
    {
        SceneManager.LoadScene("zooSam");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
