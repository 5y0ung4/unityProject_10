using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class homeManager_h : MonoBehaviour
{
    public static homeManager_h hm;

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

    public GameObject getUpLabel;
    Text getUpText;

    public GameObject nextBtn;
    Button nb;

    // Start is called before the first frame update
    void Start()
    {
        ms = MorningState.Idle;

        bg = background.GetComponent<Image>();
        getUpText = getUpLabel.GetComponent<Text>();
        nb = nextBtn.GetComponent<Button>();

        nextBtn.SetActive(false);

        StartCoroutine(GetUp());
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

        getUpLabel.SetActive(true);
        getUpText.text = "다이어리 여기있네.\n가만보자 오늘의 일정은~~";

        yield return new WaitForSeconds(3f);

        background.SetActive(true);
        bg.color = new Color32(0, 0, 0, 247);
        getUpText.color = new Color32(255, 133, 202, 255);
        getUpText.text = "<김슈니의 다이어리>\n2023.?.?\n\n1. 1-2교시 대면수업 : 50주년 기념관\n" +
            "2. 점심시간 : 교수님과 식사&면담\n3. 5-6교시 대면수업 in 제2과학관";

        yield return new WaitForSeconds(7f);

        getUpText.color = new Color32(255, 255, 255, 255);
        getUpText.text = "음 오늘은 1교시 수업이 있는 날이고~\n앗 교수님 면담이 오늘이었구나!\n" +
            "그리고 제2과에서 수업도 있었네..";

        yield return new WaitForSeconds(4f);

        getUpText.text = "오늘은 좀 바쁜 하루가 되겠어!\n어서 나갈 준비를 해야지.";

        yield return new WaitForSeconds(2f);

        getUpText.text = "~ 외출 준비중 ~";

        yield return new WaitForSeconds(2f);

        background.SetActive(false);
        getUpText.color = new Color32(0, 0, 0, 255);
        getUpText.text = "이제 학교로 가야할 시간입니다!\n나가기 위해 문을 클릭해보세요 !";

        yield return new WaitForSeconds(3f);

        getUpLabel.SetActive(false);
        ms = MorningState.Run;
    }

    public IEnumerator openDoor()
    {
        ms = MorningState.Idle;

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
        SceneManager.LoadScene("Subway");
    }
}
