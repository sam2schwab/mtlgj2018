using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ClickAndDragButton : MonoBehaviour
{
    // assign this script to a "buttonManager"
    // Trigger the function onEnter from an "onEnter" event on the button
    bool isSelected = false;
    Button button; // Assign the button as the parameter for its own "onEnter" event.

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected && Input.GetMouseButton(0))
        {
            button.transform.position = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isSelected = false;
        }
    }

    public void onEnter(Button b)
    {
        button = b;
        isSelected = true;
    }
    public void onExit(Button b)
    {
        if (!Input.GetMouseButton(0))
        {
            isSelected = false;
        }
    }
}
