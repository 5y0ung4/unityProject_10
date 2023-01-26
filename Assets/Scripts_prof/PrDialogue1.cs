using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrDialogue1 : MonoBehaviour
{
    public Text labelStartText;
    public Button ButtonA;
    public Button ButtonB;


    //public GameObject ChangeImage_pr;
    //Image thisImg;

    private void Start()
    {
        ButtonA.onClick.AddListener(OnClickButtonA);
        ButtonB.onClick.AddListener(OnClickButtonB);

        void OnClickButtonA()
        {
            
            labelStartText.text = "그래";
            //ChangeImage_pr.GetComponent<ChangeImage_pr>().ChangeImage1();
            
        }

        void OnClickButtonB()
        {
            
            labelStartText.text = "허허. 미안하구나.";
        }

    }

   
}