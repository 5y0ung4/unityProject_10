using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart_pr : MonoBehaviour
{
    public GameObject BeforeGame;
    
    // Start is called before the first frame update
    void Start()
    {
        BeforeGame.SetActive(true);
    }

    // Update is called once per frame


    

    public void onClickButtonDown()
    {
        BeforeGame.SetActive(false);
    }

}
