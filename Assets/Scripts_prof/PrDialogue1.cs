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



    //public GameObject ChangeImage_pr;
    //Image thisImg;

    private void Start()
    {
        ButtonA.onClick.AddListener(OnClickButtonA);

        ButtonB.onClick.AddListener(OnClickButtonB);

        ButtonC.onClick.AddListener(OnClickButtonC);




        void OnClickButtonA()
        {
            
            labelStartText.text = "그래. 잘 지냈니?";
            //ChangeImage_pr.GetComponent<ChangeImage_pr>().ChangeImage1();
           
            currentdegree= likedegree--;
           ldslider.value = (float)likedegree / mxlikedegree;

            
        }

        void OnClickButtonB()
        {
            
            labelStartText.text = "허허. 미안하구나.";
            currentdegree = likedegree--;
            ldslider.value = (float)likedegree / mxlikedegree;
        }

        void OnClickButtonC()
        {

            labelStartText.text = "그래 씩씩하구나. 아주 좋아!";
            
        }

    }

   
}