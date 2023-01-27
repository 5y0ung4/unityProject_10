using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayButton : MonoBehaviour
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
        CGameManager.gm.instructionImage.SetActive(false);
        CGameManager.gm.gameLabel.SetActive(false);
        CGameManager.gm.playButton.SetActive(false);

        CGameManager.gm.gState = CGameManager.GameState.Run;
    }
}
