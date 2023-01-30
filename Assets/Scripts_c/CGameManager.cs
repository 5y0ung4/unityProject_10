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
        gameText.text = "강의실에 도착했다";
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

            gameText.text = "<size=70><color=#DE6EA0>게임 설명</color></size>\n\n몰려오는 졸음을 피하자!\n아이템을 먹으면 졸음을 이겨낼 수 있어\n게이지를 다 채운 후에 아이템을 먹으면 <color=#DBAE0A>보너스</color><color=#EA93A7>♥</color>점수가 있다는 점!\n\n\n<color=#495251>오른쪽(A) 왼쪽(D)</color>";
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
            gameText.text = "드디어 강의가 끝났다. . .\n\n오늘은 교수님과 점심 식사를 하기로 했다\n\n연구실로 가자▼";
            gameText.color = new Color32(255, 255, 255, 255);
            gameText.fontSize = 50;

            homeButton.SetActive(true);
        }

        if (gState == GameState.Loading)
        {
            loading = GameObject.Find("Canvas").transform.GetChild(9).gameObject;
            loading.SetActive(true);

            gameText.text = "연구실로 이동 중\n\n<color=#FFFEC0>마우스 오른쪽 버튼을 누르면\n현재 스코어 확인 가능!</color>";
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
