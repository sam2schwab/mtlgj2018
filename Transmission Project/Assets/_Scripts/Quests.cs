using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
    public Types[] types;

    public Sprite spriteBow;
    public Sprite spriteSword;
    public Sprite spriteDagger;
    public Sprite spriteHat;
    public Sprite spriteEmpty;

    public GameObject checkmark;

    const string DIFFICULTY_BASE_TEXT = "Diff: ";

    public GameObject[] classes;

    public int difficulty;

    public TextMesh difficultyText;

    // Use this for initialization
    void Start()
    {
        difficultyText.text = DIFFICULTY_BASE_TEXT + difficulty.ToString();
        for (int i = 0; i < classes.Length; i++)
        {
            classes[i].GetComponent<SpriteRenderer>().sprite = spriteEmpty;
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
            classes[i].GetComponent<SpriteRenderer>().sprite = toAssign;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AssignHero(int power)
    {
        if (difficulty >= power)
        {
            difficulty = difficulty - power;
        }
        else
            difficulty = 0;
        difficultyText.text = DIFFICULTY_BASE_TEXT + difficulty.ToString();
    }

    public bool ValidateType(Types t)
    {
        for (int i = 0; i < types.Length; i++)
        {
            if (t == types[i] || types[i] == Types.any)
            {
                types[i] = Types.filled;
                Instantiate(checkmark, classes[i].transform);
              //  classes[i].GetComponent<SpriteRenderer>().color = Color.green;
                //classes[i].GetComponent<SpriteRenderer>().enabled = false;
                return true;
            }
        }
        return false;
    }
}
