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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WscoreSlider.value = (float)WcurrentScore / (float)WmaxScore;
    }
}
