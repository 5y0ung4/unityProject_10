using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceWindowRun : MonoBehaviour
{
    public GameObject ChoiceWindow1;
   

    // Start is called before the first frame update
    void Start()
    {
        //ChoiceWindow1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        
       
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            ChoiceWindow1.SetActive(true);
        }
    }
}
