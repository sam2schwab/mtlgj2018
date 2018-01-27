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
    filled
}

public class DragCard : MonoBehaviour
{
    public Types type;
    public int power = 0;
    public int cost = 0;
    bool isSelected = false;
    Vector3 originalPosition;
    Manager manager;
    TextMesh powerText;
    TextMesh costText;
    // Use this for initialization
    void Start()
    {
        originalPosition = transform.position;
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        powerText = this.transform.GetChild(0).gameObject.GetComponent<TextMesh>();
        costText = this.transform.GetChild(1).gameObject.GetComponent<TextMesh>();
        powerText.text = "Power: " + power.ToString();
        costText.text = "Cost: " + cost.ToString();
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
                    Quests quest = hit.transform.gameObject.GetComponent<Quests>();
                    if (quest.ValidateType(type) && manager.ValidateCost(cost))
                    {
                        manager.PayCost(cost);
                        quest.AssignHero(power);
                        Destroy(this.gameObject);
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
    //void OnMouseExit()
    //{
    //    if (!Input.GetMouseButton(0))
    //    {
    //        isSelected = false;
    //    }
    //}
}
