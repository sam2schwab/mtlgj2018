using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;          //GameManager prefab to instantiate.
    public GameObject soundManager;         //SoundManager prefab to instantiate.
    public TavernOnMap tavernPrefab;


    void Awake()
    {
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (TransmissionManager.instance == null)
        {
            //Instantiate gameManager prefab
            Instantiate(gameManager);
            gameManager.GetComponent<TransmissionManager>().tavernPrefab = tavernPrefab;
        }
        else
        {
           TransmissionManager.instance.LoadStateOfMap();
        }

        //Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
        //if (SoundManager.instance == null)
        //{
        //    //Instantiate SoundManager prefab
        //    Instantiate(soundManager);
        //}
    }
}
