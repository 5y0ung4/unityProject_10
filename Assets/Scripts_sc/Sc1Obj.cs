using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc1Obj : MonoBehaviour
{
    public static Sc1Obj Instance;
    public static bool scene1 = false;
    public int score;

    GameObject heart1;
    GameObject heart2;
    GameObject heart3;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        heart1 = GameObject.Find("Heart").transform.GetChild(0).gameObject;
        heart2 = GameObject.Find("Heart").transform.GetChild(1).gameObject;
        heart3 = GameObject.Find("Heart").transform.GetChild(2).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject scObject = GameObject.Find("Player");
        CPlayerMove sc = scObject.GetComponent<CPlayerMove>(); // dontdestroy 할지말지결정

        if ((CGameManager.gm.gState == CGameManager.GameState.Loading) && (sc.score >= 0 && sc.score <= 20) && (heart1.activeSelf == false) && (heart2.activeSelf == false) && (heart3.activeSelf == false))
        {
            this.score = -15;
        }
        else if (CGameManager.gm.gState == CGameManager.GameState.Loading && (sc.score > 20 && sc.score <= 40) && (heart1.activeSelf == false) && (heart2.activeSelf == false) && (heart3.activeSelf == false))
        {
            score = -10;
        }
        else if (CGameManager.gm.gState == CGameManager.GameState.Loading && (sc.score > 40 && sc.score <= 50) && (heart1.activeSelf == false) && (heart2.activeSelf == false) && (heart3.activeSelf == false))
        {
            score = -5;
        }
        else if (CGameManager.gm.gState == CGameManager.GameState.Loading && (sc.score > 50 && sc.score <= 70) && (heart1.activeSelf == false) && (heart2.activeSelf == false) && (heart3.activeSelf == false))
        {
            score = 5;
        }
        else if (CGameManager.gm.gState == CGameManager.GameState.Loading && (sc.score > 70 && sc.score <= 90) && (heart1.activeSelf == false) && (heart2.activeSelf == false) && (heart3.activeSelf == false))
        {
            score = 7;
        }
        else if (CGameManager.gm.gState == CGameManager.GameState.Loading && (sc.score > 90 && sc.score <= 100) && (heart1.activeSelf == false) && (heart2.activeSelf == false) && (heart3.activeSelf == false))
        {
            score = 9;
        }
        else if (CGameManager.gm.gState == CGameManager.GameState.Loading && (sc.score >= 0 && sc.score <= 150) && (heart1.activeSelf == true))
        {
            score = 11;
        }
        else if (CGameManager.gm.gState == CGameManager.GameState.Loading && (sc.score >= 0 && sc.score <= 150) && (heart1.activeSelf == true) && (heart2.activeSelf == true))
        {
            score = 13;
        }
        else if (CGameManager.gm.gState == CGameManager.GameState.Loading && (sc.score >= 0 && sc.score <= 150) && (heart1.activeSelf == true) && (heart2.activeSelf == true) && (heart3.activeSelf == true))
        {
            score = 15;
        }
        else
            return;

        scene1 = true;
    }
}
