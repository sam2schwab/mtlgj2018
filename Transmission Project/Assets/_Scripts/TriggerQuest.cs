using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuest : MonoBehaviour {
    public GameObject questToTrigger;
    Quests q;
	// Use this for initialization
	void Start () {
        q = questToTrigger.GetComponent<Quests>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AssignHero(Types type, int power)
    {
        q.AssignHero(type, power);
    }

    public bool ValidateType(Types type)
    {
        return q.ValidateType(type);
    }
}
