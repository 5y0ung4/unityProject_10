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
    // °¨¼Ò Æø °¢ ½ºÅ©¸³Æ®¿¡¼­ ÁöÁ¤

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

        if (sceneScore >= 0)
        {
            text.text = "»ÑµíÇÔ " + sceneScore + "Á¡ »ó½Â!" + WcurrentScore;
        }
        else if (sceneScore < 0)
        {
            text.text = "ÇÇ°ïÇÔ " + Mathf.Abs(sceneScore) + "Á¡ »ó½Â!" + WcurrentScore;
        }
    }
}
