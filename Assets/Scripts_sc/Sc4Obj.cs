using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc4Obj : MonoBehaviour
{
    public static Sc4Obj Instance;
    public static bool scene4 = false;
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
        if (S2GameManager.gm.gState == S2GameManager.GameState.SuccessEnd)
        {
            score = 15;
        }
        else if (S2GameManager.gm.gState == S2GameManager.GameState.OverEnd)
        {
            score = -15;
        }
        scene4 = true;
    }
}
