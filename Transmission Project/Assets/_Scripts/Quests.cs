using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
    public Types[] types;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AssignHero(Types type, int power)
    {

    }

    public bool ValidateType(Types t)
    {
        for (int i = 0; i < types.Length; i++)
        {
            if (t == types[i] || types[i] == Types.any)
            {
                types[i] = Types.filled;
                return true;
            }
        }
        return false;
    }
}
