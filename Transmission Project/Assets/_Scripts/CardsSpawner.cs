using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardsSpawner : MonoBehaviour
{
    public List<Hero> tavernHeroes;

    public GameObject cardPrefab;
    public float offsetX;
    // Use this for initialization
    void Awake()
    {
        tavernHeroes = FindObjectOfType<TransmissionManager>().currentTavern.heroes;
    }

    void Start()
    {
        //FindObjectOfType<Manager>().nbOfHeroes = tavernHeroes.Count;
        for (int i = 0; i < tavernHeroes.Count; i++)
        {
            GameObject go = Instantiate(cardPrefab, transform) as GameObject;
            go.transform.position = new Vector3(transform.position.x + i * offsetX, transform.position.y, transform.position.z);
            go.GetComponent<DragCard>().self = tavernHeroes[i];
        }
        //FindObjectOfType<Manager>().nbOfHeroes = tavernHeroes.Count;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class Hero
{
    public Types type;
    public int cost;
    public int power;
}
