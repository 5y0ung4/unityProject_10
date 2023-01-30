using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{

    public GameObject gameDescribed;

    public GameObject ImageDescribed;

    public GameObject ImageDescribed2;

    public GameObject ImageBackg;

    public GameObject Title;

    public GameObject Button;

    public int clickTime = 0;

    public Text describeText;

    public Text bT;


    //public GameObject gameLabel;

    //public GameObject gameLabel2;

    //Text gameText;

    //Text addText;

    // Start is called before the first frame update
    void Start()
    {
        describeText = gameDescribed.GetComponent<Text>();

        //addText = gameLabel2.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        //int clickTime = 0;
        Debug.Log("click");

        if (clickTime == 0)
        {
            gameDescribed.SetActive(false);

            ImageDescribed.SetActive(true);
            Title.SetActive(false);
        }

        //else if (clickTime == 1)
        //{

        //}

        else if (clickTime == 1)
        {

            ImageDescribed.SetActive(false);
            ImageDescribed2.SetActive(true);
            bT.GetComponent<Text>().text = "게임 시작";

        }

        else if (clickTime == 2)
        {

            Button.SetActive(false);
            ImageDescribed2.SetActive(false);
            GameManager.gm.gState = GameManager.GameState.Ready;
            ImageBackg.SetActive(false);


        }

        else if (clickTime > 2)
        {
            SceneManager.LoadScene("Subway2D");
        }

        clickTime += 1;

    }

   
}
