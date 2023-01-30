using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public enum GameState
    {
        Describe,
        Ready,
        Run,
        GameOver,
        Success,
        Fail,
        Cat,
        Pseudo,
        Stranger,
        Breakaway,
        Misunderstand,
        Extra
    }

    public GameState gState;

    public GameObject gameLabel;

    public GameObject gameLabel2;

    public Text gameText;

    public Text addText;

    public Transform done;

    //public GameObject startButton;

    //Button gameButton;

    PlayerMove player;

    ButtonClick buttonScript;

    public bool flag = false;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    public GameObject gameOverImage;

    // Start is called before the first frame update
    void Start()
    {
        //gState = GameState.Ready;
        gState = GameState.Describe;

        gameText = gameLabel.GetComponent<Text>();

        addText = gameLabel2.GetComponent<Text>();

        

        //gameButton = startButton.GetComponent<Button>();

        //gameText.text = "준비...";
        //gameText.color = new Color32(255, 180, 0, 255);

        //StartCoroutine(ReadyToStart());

        player = GameObject.Find("Player").GetComponent<PlayerMove>();
        buttonScript = GameObject.Find("startButton").GetComponent<ButtonClick>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (gState)
        {
            case GameState.Ready:
                Ready();
                break;

            case GameState.Success:
                Success();
                break;

            case GameState.Fail:
                Fail();
                break;

            case GameState.GameOver:
                GameOver();
                break;

            case GameState.Cat:
                Cat();
                break;

            case GameState.Pseudo:
                Pseudo();
                break;

            case GameState.Stranger:
                Stranger();
                break;

            case GameState.Breakaway:
                Breakaway();
                break;

            case GameState.Misunderstand:
                Misunderstand();
                break;

            case GameState.Run:
                Run();
                break;




        }

        void Ready()
        {
            gameText.text = "준비...";
            gameText.color = new Color32(255, 180, 0, 255);

            StartCoroutine(ReadyToStart());
        }

        void Run()
        {
            if (gState != GameState.Success && player.time <= 0)
            {

                gState = GameState.Fail;
            }

            player.time -= Time.deltaTime;
        }

        void Success()
        {
            done = player.transform;

            gameOverImage.SetActive(true);
            //player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);

            flag = true;

            gameLabel.SetActive(true);

            gameText.text = "제 시간에 도착했다!";

            gameText.color = new Color32(255, 255, 255, 255);

            buttonScript.describeText.text = "게임 성공! \n지각도 하지 않았고, 머리에 아주 잘 들어오게 강의해 주셔서 집중이 아주 잘 되었다. \n모든 강의가 끝났으니 지하철을 타러 가 볼까?";

            StartCoroutine(ToGameOver());
        }

        void Fail()
        {
            done = player.transform;
            gameOverImage.SetActive(true);
            //player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);

            flag = false;

            gameLabel.SetActive(true);

            gameText.text = "제 시간에 찾아가기 실패.";

            buttonScript.describeText.text = "게임 실패. 열심히 뛰었지만 지각했다. \n그래도 수업은 열심히 들었지만, 왠지 오늘은 집에 빨리 가서 쉬고 싶다. \n모든 강의가 끝났으니 지하철을 타러 가자.";

            gameText.color = new Color32(255, 255, 255, 255);

            StartCoroutine(ToGameOver());
        }

        void GameOver()
        {

            gameLabel.SetActive(false);
            //buttonScript.Button.SetActive(true);

            buttonScript.ImageBackg.SetActive(true);

            

            player.transform.position = done.position;

            buttonScript.gameDescribed.SetActive(true);
            buttonScript.bT.text = "다음 게임";
        }

        void Cat()
        {
            gameLabel2.SetActive(true);

            addText.text = "슈냥이를 만나서 행복해졌다. 더 빨리 걸을 수 있을 것 같다. \n(+ 8초)";

            player.time += 8;

            gameText.color = new Color32(0, 0, 0, 255);


            StartCoroutine(AnyToRun());
        }

        void Pseudo()
        {
            gameLabel2.SetActive(true);

            addText.text = "교내를 떠도는 신천지와 마주쳤다. 왠지 피곤해진 것 같다... \n(- 5초)";

            player.time -= 5;

            gameText.color = new Color32(0, 0, 0, 255);

            StartCoroutine(AnyToRun());
        }

        void Stranger()
        {
            gameLabel2.SetActive(true);

            addText.text = "외부인이 길을 물어온다. 거절하지 못하고 알려 줬다. \n(- 7초, 갓생 게이지 증가)";

            player.time -= 7;

            gameText.color = new Color32(0, 0, 0, 255);

            StartCoroutine(AnyToRun());
        }

        void Misunderstand()
        {
            gameLabel2.SetActive(true);

            addText.text = "이 건물은 제 2 과학관이 아니다. 다른 건물을 찾아보자.";

            gameText.color = new Color32(0, 0, 0, 255);

            //gameLabel2.SetActive(false);

            StartCoroutine(AnyToRun());
        }

        void Breakaway()
        {
            gameLabel2.SetActive(true);

            addText.text = "이쪽으로 더 가면 왠지 학교를 벗어날 것 같다... 다른 길을 찾아 보자.";

            gameText.color = new Color32(0, 0, 0, 255);

            StartCoroutine(AnyToRun());
        }


        //코루틴
        IEnumerator ReadyToStart()
        {

            yield return new WaitForSeconds(2f);

            gState = GameState.Run;

            gameText.text = "Start!";

            yield return new WaitForSeconds(0.5f);

            gameLabel.SetActive(false);

            gameOverImage.SetActive(false);

        }

        IEnumerator AnyToRun()
        {
            gState = GameState.Run;

            yield return new WaitForSeconds(1.5f);

            addText.text = " ";
            //gameLabel2.SetActive(false);




        }

        IEnumerator ToGameOver()
        {

            yield return new WaitForSeconds(2f);

            gState = GameState.Extra;

            gameText.text = "게임 결과 로딩 중. . .";

            yield return new WaitForSeconds(1.5f);

            gState = GameState.GameOver;

        }
    }
}
