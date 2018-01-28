using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernOnMap : MonoBehaviour {

    private Color revealedColor = Color.white;
    private Color hiddenColor = new Color(0.35f, 0.35f, 0.35f, 1);

    public Sprite spriteBow;
    public Sprite spriteSword;
    public Sprite spriteDagger;
    public Sprite spriteHat;
    public Sprite spriteAny;

    private const int MAX_LEVEL = 20;

    public GameObject dataModel;

    public List<Hero> heroes;
    public Types[] types;
    public Vector3 pos;
    public int averageLevel;
    public int id;

    static private System.Random r;

    static TavernOnMap()
    {
        r = new System.Random();
    }

    bool revealed;

    public bool Revealed
    {
        get
        {
            return revealed;
        }

        set
        {
            revealed = value;
            UpdateIcons();
        }
    }

    private void UpdateIcons()
    {
        //update visibility
        GetComponent<SpriteRenderer>().material.color = Revealed ? revealedColor : hiddenColor;

        //update icons
        var typeArray = Revealed ? heroes.Select(x => x.type).ToArray() : types;
        var icons = transform.Find("_Icons").GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < icons.Length; i++)
        {
            var icon = icons[i];
            if (i < typeArray.Length)
            {
                switch (typeArray[i])
                {
                    case Types.knight:
                        icon.sprite = spriteSword;
                        break;
                    case Types.thief:
                        icon.sprite = spriteDagger;
                        break;
                    case Types.mage:
                        icon.sprite = spriteHat;
                        break;
                    case Types.ranger:
                        icon.sprite = spriteBow;
                        break;
                    case Types.any:
                        icon.sprite = spriteAny;
                        break;
                }
            }
            else
            {
                icon.sprite = null;
            }
        } 
    }

    // Use this for initialization
    void Start () {
        if (heroes == null)
            GenerateHeroes();
        UpdateIcons();
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void GenerateHeroes()
    {
        heroes = new List<Hero>();
        foreach (var heroType in types)
        {
            var level = LevelGenerator();
            heroes.Add(new Hero
            {
                power = level,
                type = (heroType == Types.any) ? GenerateType() : heroType
            });
        }
        Revealed = false;
    }

    private Types GenerateType()
    {
        return (Types)r.Next(4);
    }

    public int LevelGenerator()
    {
        return r.Next(MAX_LEVEL) + 1;
    }
}
