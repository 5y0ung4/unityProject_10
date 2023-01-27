using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyManager : MonoBehaviour
{
    float currentTime;
    public float createTime = 1;
    public GameObject enemyFactory;
    float minTime = 0.5f;
    float maxTime = 1f;

    public int poolSize = 10;
    public List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
        enemyObjectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CGameManager.gm.gState != CGameManager.GameState.Run)
        {
            return;
        }

        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            GameObject enemy = enemyObjectPool[0];

            if (enemyObjectPool.Count > 0)
            {
                enemy.SetActive(true);
                enemyObjectPool.Remove(enemy);
                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
            }

            createTime = Random.Range(minTime, maxTime);

            currentTime = 0;
        }
    }
}
