using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Castle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnArrival()
    {
        foreach (var tavern in FindObjectsOfType<TavernOnMap>())
        {
            tavern.GenerateHeroes();
        }
    }
}
