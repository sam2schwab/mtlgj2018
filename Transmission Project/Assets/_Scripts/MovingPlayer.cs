using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour {

    private const float DURATION = 1;

    private bool moving;
    private AnimationCurve anim;
    private Vector3 dest;
    private Vector3 movement;
    private float startTime;
    private int currentCost;

	// Use this for initialization
	void Start () {
        moving = false;
        anim = AnimationCurve.EaseInOut(0, 0, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            float t = (Time.time - startTime) / DURATION;
            Vector3 position;
            if (t < 1.0f)
            {
                float ratio = anim.Evaluate(t);
                position = dest - movement * (1 - ratio);
            }
            else
            {
                position = dest; //1 or larger means we reached the end
                moving = false;
                FindObjectOfType<GameManager>().AddTimeElapsed(currentCost);
                UpdateAllCosts();
            }
            transform.position = position;
        }
	}

    public void MoveTo(Vector3 destination, int cost)
    {
        if (!moving)
        {
            moving = true;
            startTime = Time.time;
            dest = destination;
            movement = destination - transform.position;
            currentCost = cost;
        }

    }

    private void UpdateAllCosts()
    {
        GameObject[] destinations = GameObject.FindGameObjectsWithTag("Destination");

        foreach (GameObject dest in destinations)
        {
            dest.GetComponent<Selectable>().UpdateCost();
        }
    }
}
