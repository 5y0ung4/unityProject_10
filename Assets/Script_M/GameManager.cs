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

        gameText.text = "준비...";
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

            gameText.text = "제 시간에 찾아가기 실패... 지각했다.";

            gameText.color = new Color32(255, 255, 255, 255);

            

            gState = GameState.GameOver;
        }

        if(gState == GameState.Success)
        {
            gameOverImage.SetActive(true);
            //player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);

            gameLabel.SetActive(true);

            gameText.text = "지각하지 않고 제 시간에 도착해서 수업을 열심히 들었다!";

            gameText.color = new Color32(255, 255, 255, 255);
        }

        if(gState == GameState.Cat)
        {
            gameLabel2.SetActive(true);

            addText.text = "슈냥이와 마주쳐서 행복해졌다.";

            gameText.color = new Color32(0, 0, 0, 255);

            new WaitForSeconds(1f);

            gameLabel2.SetActive(false);


            gState = GameState.Run;
        }

        if (gState == GameState.Pseudo)
        {
            gameLabel2.SetActive(true);

            addText.text = "교내에 돌아다니는 신천지와 마주쳤다. 왠지 피곤해진 것 같다...";

            gameText.color = new Color32(0, 0, 0, 255);

            new WaitForSeconds(1f);

            gameLabel2.SetActive(false);

            gState = GameState.Run;
        }

        if (gState == GameState.Misunderstand)
        {
            gameLabel2.SetActive(true);

            addText.text = "이 건물은 제 2 과학관이 아니다. 다른 건물을 찾아보자.";

            gameText.color = new Color32(0, 0, 0, 255);

            new WaitForSeconds(0.5f);

            gameLabel2.SetActive(false);

            gState = GameState.Run;
        }

        if (gState == GameState.Breakaway)
        {
            gameLabel2.SetActive(true);

            addText.text = "이쪽으로 더 가면 교외인 것 같다... 다른 길을 찾아 보자.";

            gameText.color = new Color32(0, 0, 0, 255);

            new WaitForSeconds(1f);

            gameLabel2.SetActive(false);

            gState = GameState.Run;
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);

        gameText.text = "출발!!";

        yield return new WaitForSeconds(0.5f);

        gameLabel.SetActive(false);

        gState = GameState.Run;
    }
}
