using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);

            if (other.gameObject.name.Contains("Enemy"))
            {
                GameObject emObject =
                    GameObject.Find("EnemyManager");
                CEnemyManager manager =
                    emObject.GetComponent<CEnemyManager>();
                manager.enemyObjectPool.Add(other.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
