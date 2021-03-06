﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {

    GameObject player;

    GameObject MySoundManager;

    public int Cost { get; private set; }

	// Use this for initialization
	void Start () {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        if (MySoundManager == null)
            MySoundManager = GameObject.Find("SoundManager");
        UpdateCost();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnMouseEnter()
    {
        FindObjectOfType<ScriptSoundsManager>().PlayHover();
        GetComponent<SpriteRenderer>().transform.localScale *= 1.1f;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().transform.localScale /= 1.1f;
    }

    private void OnMouseDown()
    {
        FindObjectOfType<ScriptSoundsManager>().PlayClick();
        player.GetComponent<MovingPlayer>().MoveTo(this);
    }

    private int CalculateCost()
    {
        return (int)Mathf.Round((transform.position - player.transform.position).magnitude * 8);
    }

    public void UpdateCost()
    {
        Cost = CalculateCost();
        TextMesh display = GetComponentInChildren<TextMesh>();
        if (display != null)
        {
            display.text = "Cost : " + Cost;
        }
    }
}
