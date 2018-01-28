using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Mission
{
    public Types[] types;
    public int power = 0;
    public int difficulty;
    public int reward;
    public int penalty;
    //public bool readyToClaim = false;
}

public class Manager : MonoBehaviour
{
    public int resources;
    public int startingResources = 3;
    public Text text;
    public int nbOfHeroes = 0;
    public Mission[] missions;
    public GameObject[] quests;
    // Use this for initialization

    void Awake()
    {
        foreach (GameObject item in quests)
        {
            item.SetActive(false);
        }
        for (int i = 0; i < missions.Length; i++)
        {
            quests[i].SetActive(true);
            quests[i].GetComponent<Quests>().types = missions[i].types;
            quests[i].GetComponent<Quests>().UpdateIcons();
            quests[i].GetComponent<Quests>().difficulty = missions[i].difficulty;
            quests[i].GetComponent<Quests>().currentPower = missions[i].power;
        }
    }

    void Start()
    {
        resources = startingResources;
        nbOfHeroes = FindObjectOfType<CardsSpawner>().tavernHeroes.Count;
        
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
}
