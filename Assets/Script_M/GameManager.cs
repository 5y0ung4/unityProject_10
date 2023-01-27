using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public enum GameState
    {
        Ready,
        Run,
        GameOver,
        Success,
        Cat,
        Pseudo,
        Breakaway,
        Misunderstand
    }

    public GameState gState;

    public GameObject gameLabel;

    public GameObject gameLabel2;

    Text gameText;

    Text addText;

    PlayerMove player;

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
        gState = GameState.Ready;

        gameText = gameLabel.GetComponent<Text>();

        addText = gameLabel2.GetComponent<Text>();

        gameText.text = "�غ�...";
        gameText.color = new Color32(255, 180, 0, 255);

        StartCoroutine(ReadyToStart());

        player = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.time <= 0)
        {
            gameOverImage.SetActive(true);
            //player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);

            gameLabel.SetActive(true);

            gameText.text = "�� �ð��� ã�ư��� ����... �����ߴ�.";

            gameText.color = new Color32(255, 255, 255, 255);

            

            gState = GameState.GameOver;
        }

        if(gState == GameState.Success)
        {
            gameOverImage.SetActive(true);
            //player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);

            gameLabel.SetActive(true);

            gameText.text = "�������� �ʰ� �� �ð��� �����ؼ� ������ ������ �����!";

            gameText.color = new Color32(255, 255, 255, 255);
        }

        if(gState == GameState.Cat)
        {
            gameLabel2.SetActive(true);

            addText.text = "�����̿� �����ļ� �ູ������.";

            gameText.color = new Color32(0, 0, 0, 255);

            new WaitForSeconds(1f);

            gameLabel2.SetActive(false);


            gState = GameState.Run;
        }

        if (gState == GameState.Pseudo)
        {
            gameLabel2.SetActive(true);

            addText.text = "������ ���ƴٴϴ� ��õ���� �����ƴ�. ���� �ǰ����� �� ����...";

            gameText.color = new Color32(0, 0, 0, 255);

            new WaitForSeconds(1f);

            gameLabel2.SetActive(false);

            gState = GameState.Run;
        }

        if (gState == GameState.Misunderstand)
        {
            gameLabel2.SetActive(true);

            addText.text = "�� �ǹ��� �� 2 ���а��� �ƴϴ�. �ٸ� �ǹ��� ã�ƺ���.";

            gameText.color = new Color32(0, 0, 0, 255);

            new WaitForSeconds(0.5f);

            gameLabel2.SetActive(false);

            gState = GameState.Run;
        }

        if (gState == GameState.Breakaway)
        {
            gameLabel2.SetActive(true);

            addText.text = "�������� �� ���� ������ �� ����... �ٸ� ���� ã�� ����.";

            gameText.color = new Color32(0, 0, 0, 255);

            new WaitForSeconds(1f);

            gameLabel2.SetActive(false);

            gState = GameState.Run;
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);

        gameText.text = "���!!";

        yield return new WaitForSeconds(0.5f);

        gameLabel.SetActive(false);

        gState = GameState.Run;
    }
}
