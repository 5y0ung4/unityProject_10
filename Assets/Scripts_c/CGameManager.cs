using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGameManager : MonoBehaviour
{
    public static CGameManager gm;

    public GameObject gameLabel;

    public Text gameText;

    public GameObject readyImage;
    public GameObject instructionImage;
    public GameObject endingImage;

    public GameObject playButton;
    public GameObject homeButton;

    GameObject loading;

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
        Over,
        End,
        Loading
    }

    public GameState gState;

    // Start is called before the first frame update
    void Start()
    {
        gameText = gameLabel.GetComponent<Text>();
        gameText.text = "���ǽǿ� �����ߴ�";
        gameText.color = new Color32(255, 255, 255, 255);
        gameText.fontSize = 50;

        gameLabel.SetActive(true);
        readyImage.SetActive(true);

        StartCoroutine(ReadyToStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (gState == GameState.Instruction)
        {
            readyImage.SetActive(false);
            instructionImage.SetActive(true);

            gameText.text = "<size=70><color=#DE6EA0>���� ����</color></size>\n\n�������� ������ ������!\n�������� ������ ������ �̰ܳ� �� �־�\n�������� �� ä�� �Ŀ� �������� ������ <color=#DBAE0A>���ʽ�</color><color=#EA93A7>��</color>������ �ִٴ� ��!\n\n\n<color=#495251>������(A) ����(D)</color>";
            gameText.color = new Color32(50, 134, 192, 255);
            gameText.fontSize = 50;

            playButton.SetActive(true);
        }

        if (gState == GameState.Over)
        {
            endingImage.SetActive(true);

            gameLabel.SetActive(true);

            gameText.text = "<color=#44C642>Time</color><color=#FFDF7C>'</color><color=#F67C94>s</color> <color=#FFDF7C>up</color><color=#56BDFF>!</color>";
            gameText.color = new Color32(255, 255, 255, 255);
            gameText.fontSize = 70;

            StartCoroutine(Loading());
        }

        if (gState == GameState.End)
        {
            gameText.text = "���� ���ǰ� ������. . .\n\n������ �����԰� ���� �Ļ縦 �ϱ�� �ߴ�\n\n�����Ƿ� ���ڡ�";
            gameText.color = new Color32(255, 255, 255, 255);
            gameText.fontSize = 50;

            homeButton.SetActive(true);
        }

        if (gState == GameState.Loading)
        {
            loading = GameObject.Find("Canvas").transform.GetChild(9).gameObject;
            loading.SetActive(true);

            gameText.text = "�����Ƿ� �̵� ��\n\n<color=#FFFEC0>���콺 ������ ��ư�� ������\n���� ���ھ� Ȯ�� ����!</color>";
            gameText.color = new Color32(255, 255, 255, 255);
            gameText.fontSize = 60;
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);

        gState = GameState.Instruction;

    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(3f);

        gState = GameState.End;
    }
}
