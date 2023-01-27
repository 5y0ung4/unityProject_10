using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class S2Timer : MonoBehaviour
{
    //public static S2Timer s2timer;
    public string tTimer = @"남은 시간: 00.000";
    private bool isPlaying = true;
    public float totalSeconds = 60;
    public Text tText;

    // Start is called before the first frame update
    void Start()
    {
        tTimer = CountdownTimer(true);

        //gameOver = GameObject.Find("GameManager").GetComponent<S2GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (S2GameManager.gm.gState != S2GameManager.GameState.Run)
        {
            return;
        }

        if (isPlaying)
        {
            tTimer = CountdownTimer();
        }

        if (totalSeconds <= 0)
        {
            SetZero();
        }

        if (tText)
        {
            tText.text = tTimer;
        }
    }

    private string CountdownTimer(bool isUPdate = true)
    {
        if (isUPdate)
        {
            totalSeconds -= Time.deltaTime;
        }

        TimeSpan timespan = TimeSpan.FromSeconds(totalSeconds);
        string timer = "남은 시간: " + string.Format("{0:00}.{1:000}", timespan.Seconds, timespan.Milliseconds);

        return timer;
    }

    private void SetZero()
    {
        tTimer = @"00.000";
        totalSeconds = 0;
        isPlaying = false;

        S2GameManager.gm.gState = S2GameManager.GameState.GameOver;
    }
}
