using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc1Obj : MonoBehaviour
{
    public static Sc1Obj Instance;
    public static bool scene1 = false;
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
        score = 35;
        scene1 = true;
    }
}
