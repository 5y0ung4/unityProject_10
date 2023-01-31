using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc2Obj : MonoBehaviour
{
    public static Sc2Obj Instance;
    public static bool scene2 = false;
    public int score;

    public Slider ldslider;

    //public List<QuestionAndAnswer> qna;

    //GameObject endGame = QuizManager.qm.endGame.gameObject;

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
        if (ldslider.value > 0.3)
        {
            score = 15;
        }
        else if(ldslider.value <= 0.3)
        {
            score = -15;
        }
        //else
        //{
        //    return;
        //}
        
        scene2 = true;
    }
}
