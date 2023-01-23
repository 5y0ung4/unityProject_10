using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2NoteDelay : MonoBehaviour
{
    GameObject note1;
    GameObject note2;
    GameObject note3;
    GameObject note4;

    GameObject base1;
    GameObject base2;
    GameObject base3;
    GameObject base4;

    GameObject close1;
    GameObject close2;
    GameObject close3;
    GameObject close4;

    // Start is called before the first frame update
    void Start()
    {
        note1 = GameObject.Find("GameBar1").transform.GetChild(5).gameObject;
        note2 = GameObject.Find("GameBar2").transform.GetChild(5).gameObject;
        note3 = GameObject.Find("GameBar3").transform.GetChild(5).gameObject;
        note4 = GameObject.Find("GameBar4").transform.GetChild(5).gameObject;

        base1 = GameObject.Find("GameBar1").transform.GetChild(3).gameObject;
        base2 = GameObject.Find("GameBar2").transform.GetChild(3).gameObject;
        base3 = GameObject.Find("GameBar3").transform.GetChild(3).gameObject;
        base4 = GameObject.Find("GameBar4").transform.GetChild(3).gameObject;

        close1 = GameObject.Find("Metro").transform.GetChild(1).gameObject;
        close2 = GameObject.Find("Metro").transform.GetChild(2).gameObject;
        close3 = GameObject.Find("Metro").transform.GetChild(3).gameObject;
        close4 = GameObject.Find("Metro").transform.GetChild(4).gameObject;

        note1.SetActive(true);
        note2.SetActive(false);
        note3.SetActive(false);
        note4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (base1.activeSelf == false)
        {
            close1.SetActive(false);
            note2.SetActive(true);
        }
        if (base2.activeSelf == false)
        {
            close2.SetActive(false);
            note2.SetActive(false);
            note3.SetActive(true);
        }
        if (base3.activeSelf == false)
        {
            close3.SetActive(false);
            note3.SetActive(false);
            note4.SetActive(true);
        }
        if (base4.activeSelf == false)
        {
            close4.SetActive(false);
            note4.SetActive(false);
        }
    }
}
