using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2DestroyZone : MonoBehaviour
{
    GameObject note;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //note = this.gameObject;

        if (S2GameManager.gm.gState != S2GameManager.GameState.Run)
        {
            return;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (this.gameObject.activeSelf == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Hit();
            }
        }
    }

    private void Hit()
    {
        this.transform.parent.GetChild(3).gameObject.SetActive(false);
        this.transform.parent.GetChild(5).gameObject.SetActive(false);
    }
}
