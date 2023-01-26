using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2Background : MonoBehaviour
{
    public AudioSource bgmSource;

    // Start is called before the first frame update
    void Start()
    {
        bgmSource = this.GetComponent<AudioSource>();
        //bgmSource.Play();

        //if (S2GameManager.gm.gState == S2GameManager.GameState.Run)
        //{
        //    bgmSource.Play();
        //}
        //else if ((S2GameManager.gm.gState == S2GameManager.GameState.Ready) ||
        //    (S2GameManager.gm.gState == S2GameManager.GameState.Instruction) ||
        //    (S2GameManager.gm.gState == S2GameManager.GameState.Success) ||
        //    (S2GameManager.gm.gState == S2GameManager.GameState.GameOver))
        //{
        //    bgmSource.Pause();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (S2GameManager.gm.gState != S2GameManager.GameState.Run)
        {
            return;
        }
    }
}
