using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableShadow : MonoBehaviour {

    public Sprite heroWarrior;
    public Sprite heroArcher;
    public Sprite heroThief;
    public Sprite heroMage;

    Sprite toAssign;

    public int heroesRequired;
    List<Hero> heroesList;
    // Use this for initialization
    void Start () {
        heroesList = FindObjectOfType<CardsSpawner>().tavernHeroes;
        if (heroesRequired > heroesList.Count)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            //Debug.Log(heroesList.Count);
            //Debug.Log(heroesList[heroesRequired - 1].type);
            switch (heroesList[heroesRequired-1].type)
            {
                case Types.knight:
                    toAssign = heroWarrior;
                    break;
                case Types.ranger:
                    toAssign = heroArcher;
                    break;
                case Types.thief:
                    toAssign = heroThief;
                    break;
                case Types.mage:
                    toAssign = heroMage;
                    break;
            }
            GetComponent<SpriteRenderer>().sprite = toAssign;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
