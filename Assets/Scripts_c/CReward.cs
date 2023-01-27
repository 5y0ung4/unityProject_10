using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CReward : MonoBehaviour
{
    public float speed = 5;
    GameObject player;
    Vector3 dir;
    public GameObject explosionFactory;

    GameObject heart1;
    GameObject heart2;
    GameObject heart3;

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

        //heart1.SetActive(false);
        //heart2.SetActive(false);
        //heart3.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject scObject = GameObject.Find("Player");
        CPlayerMove sc = scObject.GetComponent<CPlayerMove>();

        sc.score = sc.score + 10;

        if (other.gameObject.name == "Player")
        {
            CSoundManager.soundManager.PlaySound();
        }

        heart1 = GameObject.Find("Heart").transform.GetChild(0).gameObject;
        heart2 = GameObject.Find("Heart").transform.GetChild(1).gameObject;
        heart3 = GameObject.Find("Heart").transform.GetChild(2).gameObject;

        if (sc.score == 110)
        {
            gameObject.SetActive(false);
            heart1.SetActive(true);
        }
        if ((sc.score == 120) && (heart1.activeSelf == true))
        {
            gameObject.SetActive(false);
            heart2.SetActive(true);
        }
        if ((sc.score == 130) && (heart1.activeSelf == true) && (heart2.activeSelf == true))
        {
            gameObject.SetActive(false);
            heart3.SetActive(true);
        }

        gameObject.SetActive(false);

        GameObject emObject = GameObject.Find("RewardManager");
        CRewardManager manager =
            emObject.GetComponent<CRewardManager>();

        manager.rewardObjectPool.Add(gameObject);
    }
}
