using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PRGameManager : MonoBehaviour
{
    public string[] qarray = {
        "가장 가보고 싶은 나라는?",
        "가장 좋아하는 음식은?",
        "가장 즐겨하는 스포츠는?",
        "가장 좋아하는 색깔은?",
        "방학 때 하고 싶은 것은?",
        "가장 싫어하는 것은?",
        "나의 연차는?",
        "나의 혈액형은?",
        "내가 가장 못하는 것은?",
        "나는 오늘 수업이 몇 개 남아있을까?"
    };
    public string[] Aarray = { "이집트", "떡볶이", "수영", "연분홍색", "유럽여행", "모기", "30년", "AB형", "가위바위보", "0개" };
    public string[] Barray = { "네덜란드", "곱창전골", "골프", "남색", "독서", "더위", "17년", "O형", "암산", "1개" };
    public string[] Carray = { "러시아", "녹두전 ", "탁구", "검정색 ", "휴대폰 바꾸기", "야근", "25년", "A형", "달리기", "2개" };

    public int i;

    public Text qtextUI;
    public Text savewords;

    public Text atextUI;
    public Text btextUI;
    public Text ctextUI;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TypingEffect1>()._typing();
    }



    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Dialogue());
    }

    IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<ChoiceWindowRun>();
        yield return new WaitForSeconds(0.1f);
        GetComponent<PrDialogue1>();
        while (qarray != null)
        {

            Text qtextUI = savewords;

        }
        for (i = 0; i < qarray.Length; i++)
        {
            qtextUI.text = qarray[i];

        }
        StartCoroutine(question2());
    }

    IEnumerator question2()
    {
        
        yield return new WaitForSeconds(0.1f);
        GetComponent<ChoiceWindowRun>();
    }
     
}
        
    
