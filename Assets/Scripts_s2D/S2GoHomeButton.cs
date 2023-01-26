using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2GoHomeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void homeButton()
    {
        //S2GameManager.gm.instructionImage.SetActive(false);
        S2GameManager.gm.homeButton.SetActive(false);
        S2GameManager.gm.gameLabel.SetActive(true);

        if (S2GameManager.gm.gState == S2GameManager.GameState.GameOver)
        {
            S2GameManager.gm.gState = S2GameManager.GameState.OverEnd;
        }
        else if(S2GameManager.gm.gState == S2GameManager.GameState.Success)
        {
            S2GameManager.gm.gState = S2GameManager.GameState.SuccessEnd;
        }
    }
}
