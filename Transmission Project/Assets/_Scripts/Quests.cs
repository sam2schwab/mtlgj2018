﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Quests : MonoBehaviour
{
    public Types[] types;

    public Sprite spriteBow;
    public Sprite spriteSword;
    public Sprite spriteDagger;
    public Sprite spriteHat;
    public Sprite spriteEmpty;
    public Sprite checkmark;

    public GameObject[] classes;
    public GameObject[] checkmarks;

    public int difficulty;

    public Text difficultyText;
    public Text rewardText;
    public Text penaltyText;

    // Use this for initialization
    void Start()
    {
        difficultyText.text =  difficulty.ToString();
        for (int i = 0; i < classes.Length; i++)
        {
            classes[i].GetComponent<Image>().sprite = spriteEmpty;
            checkmarks[i].GetComponent<Image>().sprite = spriteEmpty;
        }
        for (int i = 0; i < types.Length; i++)
        {
            Sprite toAssign = spriteEmpty;
            switch (types[i])
            {
                case Types.knight:
                    toAssign = spriteSword;
                    break;
                case Types.ranger:
                    toAssign = spriteBow;
                    break;
                case Types.thief:
                    toAssign = spriteDagger;
                    break;
                case Types.mage:
                    toAssign = spriteHat;
                    break;
            }
            classes[i].GetComponent<Image>().sprite = toAssign;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AssignHero(Types t, int power)
    {
        if (difficulty >= power)
        {
            difficulty = difficulty - power;
        }
        else
            difficulty = 0;
        difficultyText.text = difficulty.ToString();
        for (int i = 0; i < types.Length; i++)
        {
            if (t == types[i] || types[i] == Types.any)
            {
                types[i] = Types.filled;
                checkmarks[i].GetComponent<Image>().sprite = checkmark;
                //GameObject go = Instantiate(checkmark, classes[i].transform) as GameObject;
                //go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z - 0.1f);
            }
        }
    }

    public bool ValidateType(Types t)
    {
        for (int i = 0; i < types.Length; i++)
        {
            if (t == types[i] || types[i] == Types.any)
            {
                return true;
            }
        }
        return false;
    }
}
