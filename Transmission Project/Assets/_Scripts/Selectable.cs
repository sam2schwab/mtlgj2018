using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {

    GameObject player;
    GameObject MySoundManager;
    private int cost;

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
        GetComponent<SpriteRenderer>().flipX = true;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().flipX = false;
    }

    private void OnMouseDown()
    {
        player.GetComponent<MovingPlayer>().MoveTo(transform.position, cost);
        MySoundManager.GetComponent<ScriptSoundsManager>().PlayTrumpet();
    }

    private int CalculateCost()
    {
        return (int)Mathf.Round((transform.position - player.transform.position).magnitude * 8);
    }

    public void UpdateCost()
    {
        cost = CalculateCost();
        TextMesh display = GetComponentInChildren<TextMesh>();
        if (display != null)
        {
            display.text = "Cost : " + cost;
        }
    }
}
