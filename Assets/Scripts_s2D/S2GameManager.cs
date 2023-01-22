using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S2GameManager : MonoBehaviour
{
    public static S2GameManager gm;
    public GameObject gameLabel;
    public Text gameText;
    public GameObject readyImage;
    public GameObject instructionImage;
    public GameObject button;

    GameObject note1;
    GameObject note2;
    GameObject note3;
    GameObject note4;
    //S2Timer totalSeconds;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    public enum GameState
    {
        Ready,
        Instruction,
        Run,
        GameOver,
        Success
    }

    public GameState gState;

    // Start is called before the first frame update
    void Start()
    {
        gState = GameState.Ready;

        gameText = gameLabel.GetComponent<Text>();
        gameText.text = "지하철 역으로 이동 중 . . .";
        gameText.color = new Color32(255, 255, 255, 255);

        readyImage.SetActive(true);

        StartCoroutine(ReadyToStart());

        //totalSeconds = GameObject.Find("TimeManager").GetComponent<S2Timer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (gState == GameState.Instruction)
        {
            //StartCoroutine(Instruction());

            instructionImage.SetActive(true);
            readyImage.SetActive(false);

            gameText.text = "설명";
            button.SetActive(true);
        }

        if (gState == GameState.GameOver)
        {
            gameLabel.SetActive(true);
            gameText.text = "Game Over";
            gameText.color = new Color32(255, 0, 0, 255);
        }

        note1 = GameObject.Find("GameBar1").transform.GetChild(5).gameObject;
        note2 = GameObject.Find("GameBar2").transform.GetChild(5).gameObject;
        note3 = GameObject.Find("GameBar3").transform.GetChild(5).gameObject;
        note4 = GameObject.Find("GameBar4").transform.GetChild(5).gameObject;

        if ((note1.activeSelf == false) && (note2.activeSelf == false) && (note3.activeSelf == false)
            && (note4.activeSelf == false) && (gState == GameState.Run))
        {
            gState = GameState.Success;
        }

        if (gState == GameState.Success)
        {
            gameLabel.SetActive(true);
            gameText.text = "성공";
            gameText.color = new Color32(255, 0, 0, 255);
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);

        gState = GameState.Instruction; // gameState 변경
        //readyImage.SetActive(false); 
        // readyImage 끄기
        
    }
}
