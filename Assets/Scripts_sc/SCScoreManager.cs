using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCScoreManager : MonoBehaviour
{
    public static SCScoreManager Instance;
    public Slider WscoreSlider;
    int WmaxScore = 150;
    public int WcurrentScore = 75;
    // 감소 폭 각 스크립트에서 지정

    public Text text;

    int sceneScore;

    bool count = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Sc1ScObj.scene1)
        //{
        //    sceneScore = GameObject.Find("ScObj").GetComponent<Sc1ScObj>().score;
        //    Sc1ScObj.scene1 = false;
        //}
        //else if (Sc2ScObj.scene2)
        //{
        //    sceneScore = GameObject.Find("ScObj").GetComponent<Sc2ScObj>().score;
        //    Sc2ScObj.scene2 = false;
        //}

        if (count == false)
        {
            WcurrentScore += sceneScore;
            count = true;
        }

        WscoreSlider.value = (float)WcurrentScore / (float)WmaxScore;

        text.text = "뿌듯함 " + sceneScore + "점 상승!" + WcurrentScore;
    }
}
