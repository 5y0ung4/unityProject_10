using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceWindowRun : MonoBehaviour
{
    public GameObject ChoiceWindow;

    // Start is called before the first frame update
    void Start()
    {
        ChoiceWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            ChoiceWindow.SetActive(true);
        }
    }

    //void OnMouseDown()
    //{
       
    //}
}
