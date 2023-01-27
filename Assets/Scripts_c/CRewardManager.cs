using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRewardManager : MonoBehaviour
{
    float currentTime;
    public float createTime = 1;
    public GameObject rewardFactory;
    float minTime = 2.5f;
    float maxTime = 3f;

    public int poolSize = 10;
    public List<GameObject> rewardObjectPool;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
        rewardObjectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject reward = Instantiate(rewardFactory);
            rewardObjectPool.Add(reward);
            reward.SetActive(false);
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
            GameObject reward = rewardObjectPool[0];

            if (rewardObjectPool.Count > 0)
            {
                reward.SetActive(true);
                rewardObjectPool.Remove(reward);
                int index = Random.Range(0, spawnPoints.Length);
                reward.transform.position = spawnPoints[index].position;
            }

            createTime = Random.Range(minTime, maxTime);

            currentTime = 0;
        }
    }
}
