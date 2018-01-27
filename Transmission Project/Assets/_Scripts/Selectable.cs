using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {

    GameObject player;


	// Use this for initialization
	void Start () {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
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
        player.GetComponent<MovingPlayer>().MoveTo(transform.position);
    }
}
