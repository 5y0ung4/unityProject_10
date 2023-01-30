using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_s : MonoBehaviour
{
    public static GameManager_s gm;

    private void Awake()
    {
        if(gm==null)
        {
            gm = this;
        }
    }

    public enum GameState
    {
        Ready,
        Run,
        Success,
        Fail
    }
    public GameState gs;

    public GameObject gameLabel;
    Text gameText;

    public GameObject background;
    Image bg;
    public GameObject click;
    Image ck;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameState.Ready;

        gameText = gameLabel.GetComponent<Text>();
        bg = background.GetComponent<Image>();
        ck = click.GetComponent<Image>();

        click.SetActive(false);

        StartCoroutine(ReadyToRun()); // 게임 준비 -> 게임 시작
    }

    IEnumerator ReadyToRun()
    {
        background.SetActive(true);

        gameText.color = new Color32(178, 204, 255, 255);
        gameText.text = "헉 만석이네..\n서서 가기 싫은데...";

        yield return new WaitForSeconds(2.5f);

        gameText.text = "흠..\n내릴 것 같은 사람 앞에 서 있어보자!";

        yield return new WaitForSeconds(2.5f);

        background.SetActive(false);
        gameText.color = new Color32(93, 90, 192, 255);
        gameText.text = "곧 하차할 승객을 찾아보세요!\n준비!";
        
        yield return new WaitForSeconds(2f); // 2초간 대기

        gameText.text = "시작!";

        yield return new WaitForSeconds(0.5f); // 0.5초간 대기

        gameLabel.SetActive(false); // 게임라벨 텍스트 비활성화
        click.SetActive(true);
        gs = GameState.Run;

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator try1() // 1번 실패했을 때
    {
        gs = GameState.Ready;

        gameLabel.SetActive(true); // 게임 라벨 텍스트 활성화
        background.SetActive(true);
        click.SetActive(false);

        gameText.text = "땡!\n기회가 2번 남았습니다!";
        gameText.color = new Color32(235, 83, 158, 255);

        yield return new WaitForSeconds(2f);

        gameLabel.SetActive(false); // 비활성화
        background.SetActive(false);
        click.SetActive(true);
        gs = GameState.Run;
    }

    public IEnumerator try2() // 2번 실패했을 때
    {
        gs = GameState.Ready;

        gameLabel.SetActive(true); // 게임 라벨 텍스트 활성화
        background.SetActive(true);
        click.SetActive(false);
        gameText.text = "땡!\n기회가 1번 남았습니다!";
        gameText.color = new Color32(235, 83, 158, 255);

        yield return new WaitForSeconds(2f);

        gameLabel.SetActive(false); // 비활성화
        background.SetActive(false);
        click.SetActive(true);
        gs = GameState.Run;
    }

    public void gameOver() // 3번 실패 => 게임 오버
    {
        gameLabel.SetActive(true); // 게임 라벨 텍스트 활성화
        background.SetActive(true);
        click.SetActive(false);
        gameText.color = new Color32(237, 0, 109, 255);

        gameText.text = "Game Over\n힘들게 서서 가야겠네요...";

        gs = GameState.Fail;

        StartCoroutine(EndToFail());
    }
    IEnumerator EndToFail()
    {
        yield return new WaitForSeconds(3f);

        background.SetActive(true);
        gameText.text = "에휴...\n자리를 계속 놓치네...";
        gameText.color = new Color32(178, 204, 255, 255);

        yield return new WaitForSeconds(3.5f);

        gameText.text = "~ 이동중 ~";
        gameText.color = new Color32(181, 178, 255, 255);

        yield return new WaitForSeconds(3f);

        gameText.text = "~ 이번 역은 태릉입구역입니다  ~";

        yield return new WaitForSeconds(3f);

        gameText.text = "휴 드디어 내린다...\n지각하기 전에 어서 가야겠어.";
        gameText.color = new Color32(178, 204, 255, 255);

        yield return new WaitForSeconds(3.5f);

        gameText.text = "서서 갔더니 더 피곤한 것 같아...\n수업 때 졸진 않을까 걱정되네...";

        yield return new WaitForSeconds(3.5f);

        gameText.text = "마우스 오른쪽 버튼을 누르면\n현재 스코어 확인 가능!";
        gameText.color = new Color32(181, 178, 255, 255);
    }

    public void gameSuccess() // 게임 성공
    {
        background.SetActive(true);
        gameLabel.SetActive(true); // 게임 라벨 텍스트 활성화
        click.SetActive(false);
        gameText.color = new Color32(161, 192, 90, 255);

        gameText.text = "정답!\n앉아서 가기 성공!";

        gs = GameState.Success;

        StartCoroutine(EndToSuccess());
    }
    IEnumerator EndToSuccess()
    {
        yield return new WaitForSeconds(3f);

        gameText.text = "앗싸! 앞 사람 내린다!\n앉아서 가야지 ^_^";
        gameText.color = new Color32(178, 204, 255, 255);

        yield return new WaitForSeconds(3.5f);

        gameText.text = "~ 이동중 ~";
        gameText.color = new Color32(181, 178, 255, 255);

        yield return new WaitForSeconds(3f);

        gameText.text = "~ 이번 역은 태릉입구역입니다  ~";

        yield return new WaitForSeconds(3f);

        gameText.text = "이제 곧 내린다!\n내릴 준비 해야지";
        gameText.color = new Color32(178, 204, 255, 255);

        yield return new WaitForSeconds(3.5f);

        gameText.text = "그래도 앉아서 갔더니 훨씬 덜 피곤한 것 같네.\n컨디션 좋게 수업 들을 수 있겠다!";

        yield return new WaitForSeconds(4f);

        gameText.text = "마우스 오른쪽 버튼을 누르면\n현재 스코어 확인 가능!";
        gameText.color = new Color32(181, 178, 255, 255);
    }

}
