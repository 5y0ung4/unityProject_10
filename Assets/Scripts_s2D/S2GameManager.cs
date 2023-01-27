using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S2GameManager : MonoBehaviour
{
    public static S2GameManager gm;

    public GameObject gameLabel;
    //public GameObject instructionText;

    public Text gameText;
    //public Text instText;

    public GameObject readyImage;
    public GameObject instructionImage;
    public GameObject gameEndImage;
    public GameObject endingImage;

    public GameObject playButton;
    public GameObject homeButton;

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
        Success,
        OverEnd,
        SuccessEnd
    }

    public GameState gState;

    // Start is called before the first frame update
    void Start()
    {
        gState = GameState.Ready;

        gameText = gameLabel.GetComponent<Text>();
        gameText.text = "����ö Ÿ�� ���� ��";
        gameText.color = new Color32(255, 255, 255, 255);
        gameText.fontSize = 50;

        //instText = instructionText.GetComponent<Text>();

        readyImage.SetActive(true);

        StartCoroutine(ReadyToStart());

        //totalSeconds = GameObject.Find("TimeManager").GetComponent<S2Timer>();


    }

    // Update is called once per frame
    void Update()
    {
        loading = GameObject.Find("Canvas").transform.GetChild(8).gameObject;

        if (gState == GameState.Instruction)
        {
            //StartCoroutine(Instruction());

            loading.SetActive(false);
            readyImage.SetActive(false);
            instructionImage.SetActive(true);

            //gameLabel.SetActive(false);

            //instText = instructionText.GetComponent<Text>();
            //instructionText.SetActive(true);
            //instText.text = "����";
            //instText.color = new Color32(255, 255, 255, 255);

            gameText.text = "<size=50><color=#DB294D>���Ӽ���</color></size><color=#FFBF21>\n\n��</color>�� ���� Ŭ���ϸ� <color=#EC7786>����</color>!\n\n�ð� �ȿ� �� �̸��� �ϼ��ϸ� ���� �� �� �־�\n\n�ϼ����� ���ϸ� <color=#EC7786>���� �� ���ٴ� ���</color> ������!!"; // ����
            gameText.color = new Color32(207, 225, 245, 255);
            gameText.fontSize = 40;

            playButton.SetActive(true);
        }

        if (gState == GameState.GameOver)
        {
            gameLabel.SetActive(true);
            gameEndImage.SetActive(true);
            gameText.text = "GameOver";
            gameText.color = new Color32(255, 255, 255, 255);
            gameText.fontSize = 70;

            homeButton.SetActive(true);
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
            gameEndImage.SetActive(true);

            gameText.text = "Success!";
            gameText.color = new Color32(255, 255, 255, 255); // �� ����
            gameText.fontSize = 70;

            homeButton.SetActive(true);
        }

        if (gState == GameState.OverEnd)
        {
            endingImage.SetActive(true);

            gameText.text = "���ٰ� ���� ���� ���ƴ�\n\n���ư����� �� �ǰ������� . . . ��";
            gameText.color = new Color32(255, 255, 255, 255); // �� ����
            gameText.fontSize = 40;

            if (Input.GetMouseButton(0))
            {
                gameText.text = "������ ���� ��";
                gameText.color = new Color32(255, 255, 255, 255);
                gameText.fontSize = 40; // ������ȭ�����κ���
            }
        }

        if (gState == GameState.SuccessEnd)
        {
            endingImage.SetActive(true);

            gameText.text = "���� ���� ���� �����ߴ�\n\n������ ����! ��";
            gameText.color = new Color32(255, 255, 255, 255); // �� ����
            gameText.fontSize = 40;

            if (Input.GetMouseButton(0))
            {
                gameText.text = "������ ���� ��";
                gameText.color = new Color32(255, 255, 255, 255);
                gameText.fontSize = 40; // ������ȭ�����κ���
            }
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);

        gState = GameState.Instruction;
        
    }

    IEnumerator SuccessEnding()
    {
        
        yield return new WaitForSeconds(2f);

    }
}
