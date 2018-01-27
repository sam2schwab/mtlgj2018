using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableShadow : MonoBehaviour {
    Manager manager;
    public int heroesRequired;
	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        if (heroesRequired > manager.nbOfHeroes)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
