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
    // ���� �� �� ��ũ��Ʈ���� ����

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
