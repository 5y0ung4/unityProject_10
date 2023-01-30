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
        if (Sc1Obj.scene1)
        {
            sceneScore = GameObject.Find("ScObj").GetComponent<Sc1Obj>().score;
            Sc1Obj.scene1 = false;
        }
        else if (Sc2Obj.scene2)
        {
            sceneScore = GameObject.Find("ScObj").GetComponent<Sc2Obj>().score;
            Sc2Obj.scene2 = false;
        }

        if (count == false)
        {
            WcurrentScore += sceneScore;
            count = true;
        }

        WscoreSlider.value = (float)WcurrentScore / (float)WmaxScore;

        if (sceneScore >= 0)
        {
            text.text = "뿌듯함 " + sceneScore + "점 상승! ^.^" + WcurrentScore; // 현재 스코어 지우기
        }
        else if (sceneScore < 0)
        {
            text.text = "피곤함 " + Mathf.Abs(sceneScore) + "점 상승! T.T" + WcurrentScore;
        }
    }
}
