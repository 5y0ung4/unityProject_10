using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passangers_s : MonoBehaviour
{
    public GameObject[] passengers;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<passengers.Length;i++)
        {
            passengers[i].tag = "On";
        }

        for(int i=0;i<5;i++)
        {
            int rand = Random.Range(0, passengers.Length);
            if(passengers[rand].tag=="On")
            {
                passengers[rand].tag = "Off";
            }
            else
            {
                i--;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
