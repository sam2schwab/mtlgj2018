using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardsSpawner : MonoBehaviour
{
    public Hero[] tavernHeroes;

    public GameObject cardPrefab;
    public float offsetX;
    // Use this for initialization

    void Start()
    {
        tavernHeroes = FindObjectOfType<TransmissionManager>().currentTavern.heroes.ToArray();
        FindObjectOfType<Manager>().nbOfHeroes = tavernHeroes.Length;
        for (int i = 0; i < tavernHeroes.Length; i++)
        {
            GameObject go = Instantiate(cardPrefab, transform) as GameObject;
            go.transform.position = new Vector3(transform.position.x + i * offsetX, transform.position.y, transform.position.z);
            go.GetComponent<DragCard>().self.type = tavernHeroes[i].type;
            go.GetComponent<DragCard>().self.power = tavernHeroes[i].power;
            go.GetComponent<DragCard>().self.cost = tavernHeroes[i].cost;
        }
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
