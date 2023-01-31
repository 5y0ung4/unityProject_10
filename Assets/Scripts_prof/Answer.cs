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

    
    public void badImage()
    {
        bad.SetActive(true);
    }



    //public GameObject changeImage_pr;
    //ChangeImage_pr chpr;

    private void Start()
    {
        //GetComponent<QuizManager>();
       // GetComponent<QuizManager>().currentdegree = GetComponent<QuizManager>().mxlikedegree;
       currentdegree = mxlikedegree;
    }
    public void answer()
    {
        if (isCorrect == true)
        {
            Invoke("goodImage", 0.1f);
            IsInvoking("goodmage");
            
            Debug.Log("인버크동작중");
            
            //good.SetActive(true);
            //GetComponent<QuizManager>().ChoiceWindowRun();
            Debug.Log("정답입니다");
            //GetComponent<QuizManager>().Good();
            
            quizmanager.Next();
            
        }
        else 
        {
            bad.SetActive(true);
           // GetComponent<QuizManager>().currentdegree -= GetComponent<QuizManager>().likedegree;
            currentdegree -= likedegree;
            ldslider.value = (float)currentdegree / mxlikedegree;
            //ldslider.value = (float)Getcomponent<QuizManager>().currentdegree / Getcomponent<QuizManager>().mxlikedegree;


            //changeImage_pr.GetComponent<ChangeImage_pr>().ChangeImage1();
            //chpr.ChangeImage1();

            //GetComponent<QuizManager>().ChoiceWindowRun(); 
            Debug.Log("오답입니다");

            quizmanager.Next();

            //Invoke("badImage", 0.1f);

        }

        

        //void good()
        //    {
        //       goodImage.Set
        //    }

        //void badImage()
        //    {

        //    }



    }

    public void goodImage()
    {
        good.SetActive(true);
    }
}
