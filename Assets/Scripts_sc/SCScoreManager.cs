using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCScoreManager : MonoBehaviour
{
    public static SCScoreManager Instance;
    public Slider WscoreSlider;
    int WmaxScore = 150;
    public static int WcurrentScore = 75;
    // 감소 폭 각 스크립트에서 지정

    public Text text;

    int sceneScore;

    bool count = false;

    //private void Awake()
    //{
    //    if (Instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Sc0Obj.scene0)
        {
            sceneScore = GameObject.Find("ScObj").GetComponent<Sc0Obj>().score;
            Sc0Obj.scene0 = false;
        }
        else if (Sc1Obj.scene1)
        {
            sceneScore = GameObject.Find("ScObj").GetComponent<Sc1Obj>().score;
            Sc1Obj.scene1 = false;
        }
        else if (Sc3Obj.scene3)
        {
            sceneScore = GameObject.Find("ScObj").GetComponent<Sc3Obj>().score;
            Sc3Obj.scene3 = false;
        }
        else if (Sc4Obj.scene4)
        {
            sceneScore = GameObject.Find("ScObj").GetComponent<Sc4Obj>().score;
            Sc4Obj.scene4 = false;
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
