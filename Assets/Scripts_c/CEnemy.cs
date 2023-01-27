using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemy : MonoBehaviour
{
    public float speed = 5;
    //GameObject player;
    Vector3 dir;
    public GameObject explosionFactory;


    // Start is called before the first frame update
    void Start()
    {
        int randValue = UnityEngine.Random.Range(0, 10);

        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CGameManager.gm.gState != CGameManager.GameState.Run)
        {
            return;
        }

        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject scObject = GameObject.Find("Player");
        CPlayerMove sc = scObject.GetComponent<CPlayerMove>();

        sc.score = sc.score - 10;

        gameObject.SetActive(false);

        //if (other.gameObject.name == "Player")
        //{
        //    CSoundManager.soundManager.PlaySound();
        //}

        GameObject emObject = GameObject.Find("EnemyManager");
        CEnemyManager manager =
            emObject.GetComponent<CEnemyManager>();

        manager.enemyObjectPool.Add(gameObject);
    }
}
