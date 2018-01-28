using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {

    GameObject player;
    public int Cost { get; private set; }

	// Use this for initialization
	void Start () {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
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
