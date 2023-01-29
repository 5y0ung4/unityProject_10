using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrDialogue1 : MonoBehaviour
{
    public Text labelStartText;
    public Button ButtonA;
    public Button ButtonB;
    public Button ButtonC;



    public int likedegree=10;

    public int mxlikedegree = 100;

    public int currentdegree;

    public Slider ldslider;

    public GameObject ChoiceWindow;


    public GameObject changeImage_pr;
    ChangeImage_pr chpr;

    public string[] questionarray = { "안녕", "뭐해", "밥은?" };
    public string[] answerAarray = { "비행기", "떡볶이", "강아지" };
    public string[] answerBarray = { "파랑", "방서", "분무기" };
    public string[] answerCarray = { "노트북", "손가락", "바다" };

    public int i;

    //Image thisImg;

    private void Start()
    {
        ButtonA.onClick.AddListener(OnClickButtonA);

        ButtonB.onClick.AddListener(OnClickButtonB);

        ButtonC.onClick.AddListener(OnClickButtonC);


        currentdegree = mxlikedegree;
        //chpr = GetComponent<ChangeImage_pr>();
        chpr =GameObject.Find("smile_prof").GetComponent<ChangeImage_pr>();
        

    }

    public void OnClickButtonA()
    {

        for (i = 0; i < questionarray.Length; i++)
        {
            labelStartText.text = questionarray[i];
            //yield return new WaitUntil(ChoiceWindow = true);
        }
        
        
        
        changeImage_pr.GetComponent<ChangeImage_pr>().ChangeImage1();
        chpr.ChangeImage1();

        currentdegree -= likedegree;
        ldslider.value = (float)currentdegree / mxlikedegree;

        ChoiceWindow.SetActive(false);





    }

    void OnClickButtonB()
    {
       


        labelStartText.text = questionarray[0];
        //currentdegree = likedegree--;
        changeImage_pr.GetComponent<ChangeImage_pr>().ChangeImage2();

        currentdegree -= likedegree;
        ldslider.value = (float)currentdegree / mxlikedegree;

        ChoiceWindow.SetActive(false);

    }

    void OnClickButtonC()
    {

        labelStartText.text = "그래 씩씩하구나. 아주 좋아!";

        ChoiceWindow.SetActive(false);



    }

}