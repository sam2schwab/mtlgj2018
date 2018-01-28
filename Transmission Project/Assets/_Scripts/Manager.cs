﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    public int resources;
    public int startingResources = 3;
    public Text text;
    public int nbOfHeroes = 0;
	// Use this for initialization
	void Start () {
        resources = startingResources;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool ValidateCost(int cost)
    {
        return cost <= resources;
    }
    public void PayCost(int cost)
    {
        resources = resources - cost;
        text.text = resources.ToString()+" / " + startingResources.ToString();
    }
    public void ExitToMap()
    {
        SceneManager.LoadScene("zooSam");
    }
}
