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
        Fail,
        GameOver,
        Success
    }
    public GameState gs;

    public GameObject gameLabel;
    Text gameText;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameState.Ready;

        gameText = gameLabel.GetComponent<Text>();

        gameText.text = "곧 하차할 승객을 찾아보세요!\n\n준비!";
        gameText.color = new Color32(147, 144, 246, 255);

        StartCoroutine(ReadyToRun()); // 게임 준비 -> 게임 시작
    }

    IEnumerator ReadyToRun()
    {
        yield return new WaitForSeconds(2f); // 2초간 대기

        gameText.text = "시작!";

        yield return new WaitForSeconds(0.5f); // 0.5초간 대기

        gameLabel.SetActive(false); // 게임라벨 텍스트 비활성화
        gs = GameState.Run;

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator try1() // 1번 실패했을 때
    {
        gs = GameState.Fail;

        gameLabel.SetActive(true); // 게임 라벨 텍스트 활성화
        gameText.text = "땡!\n\n기회가 2번 남았습니다!";
        gameText.color = new Color32(235, 83, 158, 255);

        yield return new WaitForSeconds(2f);

        gameLabel.SetActive(false); // 비활성화
        gs = GameState.Run;
    }

    public IEnumerator try2() // 2번 실패했을 때
    {
        gs = GameState.Fail;

        gameLabel.SetActive(true); // 게임 라벨 텍스트 활성화
        gameText.text = "땡!\n\n기회가 1번 남았습니다!";
        gameText.color = new Color32(235, 83, 158, 255);

        yield return new WaitForSeconds(2f);

        gameLabel.SetActive(false); // 비활성화
        gs = GameState.Run;
    }

    public void gameOver() // 3번 실패 => 게임 오버
    {
        gameLabel.SetActive(true); // 게임 라벨 텍스트 활성화
        gameText.color = new Color32(237, 0, 109, 255);

        gameText.text = "Game Over\n\n당신은 서서 가야합니다...";

        gs = GameState.GameOver;
    }

    public void gameSuccess() // 게임 성공
    {
        gameLabel.SetActive(true); // 게임 라벨 텍스트 활성화
        gameText.color = new Color32(161, 192, 90, 255);

        gameText.text = "정답!\n\n앉아서 가기 성공!";

        gs = GameState.Success;
    }
}
