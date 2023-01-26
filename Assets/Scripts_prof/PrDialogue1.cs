using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrDialogue1 : MonoBehaviour
{
    public Text textUI;

    public void OnClickButtonA()
    {
        textUI.text = "그래";





    }




    public void OnClickButtonB()
    {
        textUI.text = "허허 미안하구나.";
    }
}