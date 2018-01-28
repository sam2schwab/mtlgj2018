using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum Types
{
    knight,
    ranger,
    thief,
    mage,
    any,
    filled,
}

public class DragCard : MonoBehaviour
{

    bool isSelected = false;
    Vector3 originalPosition;
    Manager manager;
    TextMesh powerText;
    TextMesh costText;

    public Hero self;
    public Sprite spriteBow;
    public Sprite spriteSword;
    public Sprite spriteDagger;
    public Sprite spriteHat;
    public Sprite spriteEmpty;


    // Use this for initialization
    void Start()
    {
        originalPosition = transform.position;
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        powerText = transform.GetChild(0).gameObject.GetComponent<TextMesh>();
        costText = transform.GetChild(1).gameObject.GetComponent<TextMesh>();
        powerText.text = "Power: " + self.power.ToString();
        costText.text = "Cost: " + self.cost.ToString();

        Sprite toAssign = spriteEmpty;
        switch (self.type)
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
        transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = toAssign;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            transform.position = new Vector3(transform.position.x, transform.position.y, -8);
            if (Input.GetMouseButtonUp(0))
            {
                isSelected = false;

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, LayerMask.GetMask("Quests"));
                if (hit.collider != null)
                {
                    TriggerQuest tq = hit.transform.gameObject.GetComponent<TriggerQuest>();
                    //Quests quest = hit.transform.gameObject.GetComponent<Quests>();
                    if (tq.ValidateType(self.type) && manager.ValidateCost(self.cost))
                    {
                        manager.PayCost(self.cost);
                        tq.AssignHero(self.type, self.power);
                        FindObjectOfType<CardsSpawner>().tavernHeroes.Remove(self);
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        transform.position = originalPosition;
                    }
                }

                else
                {
                    transform.position = originalPosition;
                }
            }
        }
    }
    void OnMouseDown()
    {
        isSelected = true;
    }
}
