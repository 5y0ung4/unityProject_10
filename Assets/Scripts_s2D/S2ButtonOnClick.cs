using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2ButtonOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playButton()
    {
        S2GameManager.gm.instructionImage.SetActive(false);
        S2GameManager.gm.gameLabel.SetActive(false);
        //S2GameManager.gm.instructionText.SetActive(false);
        S2GameManager.gm.playButton.SetActive(false);

        S2GameManager.gm.gState = S2GameManager.GameState.Run;
    }
}
