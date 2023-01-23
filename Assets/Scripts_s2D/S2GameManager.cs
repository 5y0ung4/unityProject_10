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

    GameObject base1;
    GameObject base2;
    GameObject base3;
    GameObject base4;

    GameObject loading;

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
        gameText.text = "Loading";
        gameText.color = new Color32(255, 255, 255, 255);


        readyImage.SetActive(true);

        StartCoroutine(ReadyToStart());

        //totalSeconds = GameObject.Find("TimeManager").GetComponent<S2Timer>();


    }

    // Update is called once per frame
    void Update()
    {
        loading = GameObject.Find("Canvas").transform.GetChild(5).gameObject;

        if (gState == GameState.Instruction)
        {
            //StartCoroutine(Instruction());

            loading.SetActive(false);
            instructionImage.SetActive(true);
            readyImage.SetActive(false);

            gameText.text = "Ό³Έν";
            button.SetActive(true);
        }

        if (gState == GameState.GameOver)
        {
            gameLabel.SetActive(true);
            gameText.text = "GameOver";
            gameText.color = new Color32(255, 0, 0, 255);
        }

        base1 = GameObject.Find("GameBar1").transform.GetChild(3).gameObject;
        base2 = GameObject.Find("GameBar2").transform.GetChild(3).gameObject;
        base3 = GameObject.Find("GameBar3").transform.GetChild(3).gameObject;
        base4 = GameObject.Find("GameBar4").transform.GetChild(3).gameObject;

        if ((base1.activeSelf == false) && (base2.activeSelf == false) && (base3.activeSelf == false)
            && (base4.activeSelf == false) && (gState == GameState.Run))
        {
            gState = GameState.Success;
        }

        if (gState == GameState.Success)
        {
            gameLabel.SetActive(true);
            gameText.text = "Success!";
            gameText.color = new Color32(255, 0, 0, 255);
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);

        gState = GameState.Instruction; // gameState Ί―°ζ
        //readyImage.SetActive(false); 
        // readyImage ²τ±β
        
    }
}
