using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingPlayer : MonoBehaviour {

    private const float DURATION = 1;

    private bool moving;
    private AnimationCurve anim;
    private Selectable destObj;
    private Vector3 movement;
    private float startTime;

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
                position = destObj.transform.position - movement * (1 - ratio);
            }
            else
            {
                position = destObj.transform.position; //1 or larger means we reached the end
                moving = false;
                OnArrival();
            }
            transform.position = position;
        }
	}

    private void OnArrival()
    {
        FindObjectOfType<ScriptSoundsManager>().PlayTrumpet();
        var manager = FindObjectOfType<TransmissionManager>();
        var tavern = destObj.GetComponent<TavernOnMap>();
        if (tavern != null)
        {
            manager.EnterTavern(destObj);
            tavern.Revealed = true;
            manager.SaveStateOfMap();
            SceneManager.LoadScene("main");
        }
        else
        {
            var castle = destObj.GetComponent<Castle>();
            if (castle != null)
            {
                castle.OnArrival();
            }
        }
        UpdateAllCosts();
    }

    public void MoveTo(Selectable obj)
    {
        if (!moving)
        {
            moving = true;
            startTime = Time.time;
            destObj = obj;
            movement = destObj.transform.position - transform.position;
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
