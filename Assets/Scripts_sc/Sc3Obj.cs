using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc3Obj : MonoBehaviour
{
    public static Sc3Obj Instance;
    public static bool scene3 = false;
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
        if (GameManager.gm.gState == GameManager.GameState.Fail)
        {
            score = -15;
        }
        else if (GameManager.gm.gState == GameManager.GameState.Success)
        {
            score = 15;
        }
        scene3 = true;
    }
}
