using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public QuizManager quizmanager;
    
    public bool isCorrect =false;

    public int likedegree = 10;

    public int mxlikedegree = 100;

    public int currentdegree;

    public Slider ldslider;

    public GameObject ChoiceWindow1;

    public GameObject good;

    public GameObject bad;



    //public GameObject changeImage_pr;
    //ChangeImage_pr chpr;

    private void Start()
    {
        currentdegree = mxlikedegree;
    }
    public void answer()
    {
        if (isCorrect == true)
        {
            //GetComponent<QuizManager>().ChoiceWindowRun();
            Debug.Log("정답입니다");
            //GetComponent<QuizManager>().Good();
            //good.SetActive(true);
            quizmanager.Next();
        }
        else 
        {
            bad.SetActive(true);
            currentdegree -= likedegree;
            ldslider.value = (float)currentdegree / mxlikedegree;

            //changeImage_pr.GetComponent<ChangeImage_pr>().ChangeImage1();
            //chpr.ChangeImage1();

            //GetComponent<QuizManager>().ChoiceWindowRun(); 
            Debug.Log("오답입니다");

            quizmanager.Next();
        }
        
        
       
    }
}
