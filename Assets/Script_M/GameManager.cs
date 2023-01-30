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

        //gameText.text = "�غ�...";
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
            gameText.text = "�غ�...";
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

            gameText.text = "�� �ð��� �����ߴ�!";

            gameText.color = new Color32(255, 255, 255, 255);

            buttonScript.describeText.text = "���� ����! \n������ ���� �ʾҰ�, �Ӹ��� ���� �� ������ ������ �ּż� ������ ���� �� �Ǿ���. \n��� ���ǰ� �������� ����ö�� Ÿ�� �� ����?";

            StartCoroutine(ToGameOver());
        }

        void Fail()
        {
            done = player.transform;
            gameOverImage.SetActive(true);
            //player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);

            flag = false;

            gameLabel.SetActive(true);

            gameText.text = "�� �ð��� ã�ư��� ����.";

            buttonScript.describeText.text = "���� ����. ������ �پ����� �����ߴ�. \n�׷��� ������ ������ �������, ���� ������ ���� ���� ���� ���� �ʹ�. \n��� ���ǰ� �������� ����ö�� Ÿ�� ����.";

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
            buttonScript.bT.text = "���� ����";
        }

        void Cat()
        {
            gameLabel2.SetActive(true);

            addText.text = "�����̸� ������ �ູ������. �� ���� ���� �� ���� �� ����. \n(+ 8��)";

            player.time += 8;

            gameText.color = new Color32(0, 0, 0, 255);


            StartCoroutine(AnyToRun());
        }

        void Pseudo()
        {
            gameLabel2.SetActive(true);

            addText.text = "������ ������ ��õ���� �����ƴ�. ���� �ǰ����� �� ����... \n(- 5��)";

            player.time -= 5;

            gameText.color = new Color32(0, 0, 0, 255);

            StartCoroutine(AnyToRun());
        }

        void Stranger()
        {
            gameLabel2.SetActive(true);

            addText.text = "�ܺ����� ���� ����´�. �������� ���ϰ� �˷� ���. \n(- 7��, ���� ������ ����)";

            player.time -= 7;

            gameText.color = new Color32(0, 0, 0, 255);

            StartCoroutine(AnyToRun());
        }

        void Misunderstand()
        {
            gameLabel2.SetActive(true);

            addText.text = "�� �ǹ��� �� 2 ���а��� �ƴϴ�. �ٸ� �ǹ��� ã�ƺ���.";

            gameText.color = new Color32(0, 0, 0, 255);

            //gameLabel2.SetActive(false);

            StartCoroutine(AnyToRun());
        }

        void Breakaway()
        {
            gameLabel2.SetActive(true);

            addText.text = "�������� �� ���� ���� �б��� ��� �� ����... �ٸ� ���� ã�� ����.";

            gameText.color = new Color32(0, 0, 0, 255);

            StartCoroutine(AnyToRun());
        }


        //�ڷ�ƾ
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

            gameText.text = "���� ��� �ε� ��. . .";

            yield return new WaitForSeconds(1.5f);

            gState = GameState.GameOver;

        }
    }
}
