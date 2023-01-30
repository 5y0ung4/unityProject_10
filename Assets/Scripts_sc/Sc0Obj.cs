using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc0Obj : MonoBehaviour
{
    public static Sc0Obj Instance;
    public static bool scene0 = false;
    public int score;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager_s.gm.gs == GameManager_s.GameState.Fail)
        {
            score = -15;
        }
        else if (GameManager_s.gm.gs == GameManager_s.GameState.Success)
        {
            score = 15;
        }

        //score = 15;
        scene0 = true;
    }
}
