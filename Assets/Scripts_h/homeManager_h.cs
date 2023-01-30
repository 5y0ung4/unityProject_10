using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class homeManager_h : MonoBehaviour
{
    public static homeManager_h hm;

    PlayerMove_h player;
    public GameObject chair;

    int finalScore = SCScoreManager.Instance.WcurrentScore; // 최종 점수

    private void Awake()
    {
        if (hm == null)
        {
            hm = this;
        }
    }

    public enum MorningState
    {
        Run,
        Idle
    }
    public MorningState ms;

    public GameObject background;
    Image bg;
    public GameObject click;
    Image ck;

    public GameObject getUpLabel;
    Text getUpText;
    public GameObject endingLabel;
    Text ending;

    public GameObject nextBtn;
    Button nb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMove_h>();

        bg = background.GetComponent<Image>();
        ck = click.GetComponent<Image>();
        getUpText = getUpLabel.GetComponent<Text>();
        ending = endingLabel.GetComponent<Text>();
        nb = nextBtn.GetComponent<Button>();

        nextBtn.SetActive(false);
        click.SetActive(false);

        if (finalScore > 0) // 집이 스타트가 아닌 엔딩이라면
        {
            if (finalScore >= 75)
            {
                worth();
            }
            else
            {
                tired();
            }
        }
        else // 집에서 스타트
        {
            ms = MorningState.Idle;

            StartCoroutine(GetUp());
        }

    }

    public IEnumerator GetUp()
    {
        background.SetActive(true);
        yield return new WaitForSeconds(2f);
        background.SetActive(false);
        yield return new WaitForSeconds(1f);
        background.SetActive(true);
        yield return new WaitForSeconds(2f);
        background.SetActive(false);
        yield return new WaitForSeconds(1f);

        background.SetActive(true);
        bg.color = new Color32(36, 120, 255, 245);
        getUpText.text = "아침이다!\n눈이 일찍 떠졌지만 상쾌한 기분이 든다.";

        yield return new WaitForSeconds(3f);

        getUpText.text = "하루의 시작이 좋네!\n오늘은 갓생 열정으로 하루를 보내야겠다.";

        yield return new WaitForSeconds(3f);

        getUpText.text = "일단 오늘 일정부터 체크하자.\n책상 위에 둔 다이어리를 봐야겠어.";

        yield return new WaitForSeconds(4f);

        background.SetActive(false);
        getUpText.color = new Color32(0, 0, 0, 255);
        getUpText.text = "책상 위에 놓인 다이어리를 찾고 클릭해보세요 !";

        yield return new WaitForSeconds(3f);

        click.SetActive(true);
        getUpLabel.SetActive(false);
        ms = MorningState.Run;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator findDiary()
    {
        ms = MorningState.Idle;

        click.SetActive(false);
        getUpLabel.SetActive(true);
        getUpText.text = "다이어리 여기있네.\n가만보자 오늘의 일정은~~";

        yield return new WaitForSeconds(3f);

        background.SetActive(true);
        bg.color = new Color32(0, 0, 0, 247);
        getUpText.color = new Color32(255, 133, 202, 255);
        getUpText.text = "<김슈니의 다이어리>\n2023.?.?\n\n1. 1-2교시 대면수업 : 50주년 기념관\n" +
            "2. 점심시간 : 교수님과 식사&면담\n3. 5-6교시 대면수업 : 제2과학관";

        yield return new WaitForSeconds(7f);

        getUpText.color = new Color32(255, 255, 255, 255);
        getUpText.text = "음 오늘은 1교시 수업이 있는 날이고~\n앗 교수님 면담이 오늘이었구나!\n" +
            "그리고 제2과에서 수업도 있었네..";

        yield return new WaitForSeconds(4f);

        getUpText.text = "오늘은 좀 바쁜 하루가 되겠네!\n어서 나갈 준비 해야겠다";

        yield return new WaitForSeconds(2.5f);

        getUpText.text = "~ 외출 준비중 ~";

        yield return new WaitForSeconds(2f);

        background.SetActive(false);
        getUpText.color = new Color32(0, 0, 0, 255);
        getUpText.text = "이제 학교로 가야할 시간입니다!\n나가기 위해 문을 클릭해보세요 !";

        yield return new WaitForSeconds(3f);

        click.SetActive(true);
        getUpLabel.SetActive(false);
        ms = MorningState.Run;
    }

    public IEnumerator openDoor()
    {
        ms = MorningState.Idle;

        click.SetActive(false);
        getUpLabel.SetActive(true);
        background.SetActive(true);
        bg.color = new Color32(0, 0, 0, 247);
        getUpText.color = new Color32(255, 255, 255, 255);
        getUpText.text = "철컥!\n다녀오겠습니다~";

        yield return new WaitForSeconds(2f);

        getUpText.text = "지하철 타고 태입역으로 가서 셔틀 타야겠다!\n7호선 사람 많겠지?\n앉아서 가면 좋겠는데~";
        nextBtn.SetActive(true);
    }

    public void NextMap_btn()
    {
        SceneManager.LoadScene("SceneNum0");
    }

    void worth() // 뿌듯게이지 > 피곤게이지
    {
        player.transform.position = chair.transform.position; // 플레이어 이동시키기

        ms = MorningState.Idle;
        StartCoroutine(writeDiary());
    }
    IEnumerator writeDiary()
    {
        yield return new WaitForSeconds(2.5f);

        background.SetActive(true);
        bg.color = new Color32(0, 0, 0, 247);
        ending.color = new Color32(255, 255, 255, 255);
        ending.text = "오늘도 하루의 끝이 다가왔다.\n오늘의 나는 정말 열정적이었어.";

        yield return new WaitForSeconds(3f);

        ending.text = "최근들어 가장 뿌듯한 날이 바로 오늘인 것 같다.\n이런 날엔 일기를 꼭 써줘야지!";

        yield return new WaitForSeconds(3f);

        ending.text = " ~ 일기 쓰는 중 ~";
        yield return new WaitForSeconds(2f);

        ending.text = "휴 다 썼다!\n오늘같은 날이 많았으면 좋겠네~\n내일도 열심히 살자!";

    }

    void tired() // 피곤게이지 > 뿌듯게이지
    {
        ms = MorningState.Idle;

        background.SetActive(true);
        bg.color = new Color32(0, 0, 0, 255);
        ending.color = new Color32(201, 0, 73, 255);
        ending.text = "Black Out\n\n플레이어는 피곤에 찌든 나머지\n집에 도착하자마자 기절해버렸습니다.";
    }
}
