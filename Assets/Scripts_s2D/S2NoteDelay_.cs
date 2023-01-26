using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2NoteDelay_ : MonoBehaviour
{
    //GameObject note;

    string str;
    int num;
    string oName;

    // Start is called before the first frame update
    void Start()
    {
        if (this.transform.parent.name == "GameBar1")
        {
            this.gameObject.SetActive(true);
        }
        else if (this.transform.parent.name == "GameBar2"
            || this.transform.parent.name == "GameBar3"
            || this.transform.parent.name == "GameBar4")
        {
            this.gameObject.SetActive(false);
            this.transform.parent.GetChild(3).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (S2GameManager.gm.gState != S2GameManager.GameState.Run)
        {
            return;
        }

        //str = this.transform.parent.ToString();
        //num = int.Parse(str[7].ToString()) - 1;

        //oName = "GameBar" + num;
        //Debug.Log(oName);

        //if (this.transform.parent.name == "GameBar2"
        //    || this.transform.parent.name == "GameBar3"
        //    || this.transform.parent.name == "GameBar4")
        //{
        //    this.gameObject.SetActive(false);
        //    this.transform.parent.GetChild(3).gameObject.SetActive(false);
        //}
    }

    //void Delay()
    //{
    //    StopAllCoroutines();
    //    StartCoroutine(DelayProcess());
    //}

    //IEnumerator DelayProcess()
    //{
    //    yield return new WaitForSeconds(0.2f);

    //    this.gameObject.SetActive(true);
    //    this.transform.parent.GetChild(3).gameObject.SetActive(true);
    //}
}
