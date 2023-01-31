using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public GameObject qm;
    QuizManager quizmanager;
    
    public bool isCorrect =false;

    public int likedegree = 10;

    public int mxlikedegree = 100;

    public int currentdegree;

    public Slider ldslider;

    public GameObject ChoiceWindow1;

    public GameObject good;

    public GameObject bad;

    
    //public void badImage()
    //{
    //    bad.SetActive(true);
    //}



    //public GameObject changeImage_pr;
    //ChangeImage_pr chpr;

    private void Start()
    {
       quizmanager = qm.GetComponent<QuizManager>();
        if(!quizmanager)
        {
            Debug.Log("오브젝트 없음");
        }
       quizmanager.currentdegree = quizmanager.mxlikedegree;
       currentdegree = mxlikedegree;
    }
    public void answer()
    {
        if (isCorrect == true)
        {
            Invoke("goodImage", 0.01f);
            Invoke("turnoffImagegood", 2f);
            IsInvoking("goodmage");
            Debug.Log("인보크" + IsInvoking());
            
            //Debug.Log("인버크동작중");
            
            //good.SetActive(true);
            //GetComponent<QuizManager>().ChoiceWindowRun();
            Debug.Log("정답입니다");
            //GetComponent<QuizManager>().Good();
            
            quizmanager.Next();
            
        }
        else 
        {
            Invoke("badImage", 0.01f);
            Invoke("turnoffImagebad", 2f); 
            bad.SetActive(true);
           quizmanager.currentdegree -= quizmanager.likedegree;
            //currentdegree -= likedegree;
            //ldslider.value = (float)currentdegree / mxlikedegree;
            ldslider.value = (float)quizmanager.currentdegree / quizmanager.mxlikedegree;


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

    public void badImage()
    {
        bad.SetActive(true);
    }

    public void turnoffImagegood()
    {
        good.SetActive(false);
    }

    public void turnoffImagebad()
    {
        bad.SetActive(false);
    }
}
