using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGoButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goButton()
    {
        CGameManager.gm.homeButton.SetActive(false);

        CGameManager.gm.gState = CGameManager.GameState.Loading;
    }
}
