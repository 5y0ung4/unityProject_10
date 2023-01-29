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

        gameText.text = "�� ������ �°��� ã�ƺ�����!\n\n�غ�!";
        gameText.color = new Color32(168, 126, 228, 255);

        StartCoroutine(ReadyToRun()); // ���� �غ� -> ���� ����
    }

    IEnumerator ReadyToRun()
    {
        yield return new WaitForSeconds(2f); // 2�ʰ� ���

        gameText.text = "����!";

        yield return new WaitForSeconds(0.5f); // 0.5�ʰ� ���

        gameLabel.SetActive(false); // ���Ӷ� �ؽ�Ʈ ��Ȱ��ȭ
        gs = GameState.Run;

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator try1() // 1�� �������� ��
    {
        gs = GameState.Fail;

        gameLabel.SetActive(true); // ���� �� �ؽ�Ʈ Ȱ��ȭ
        gameText.text = "��!\n\n��ȸ�� 2�� ���ҽ��ϴ�!";
        gameText.color = new Color32(235, 83, 158, 255);

        yield return new WaitForSeconds(2f);

        gameLabel.SetActive(false); // ��Ȱ��ȭ
        gs = GameState.Run;
    }

    public IEnumerator try2() // 2�� �������� ��
    {
        gs = GameState.Fail;

        gameLabel.SetActive(true); // ���� �� �ؽ�Ʈ Ȱ��ȭ
        gameText.text = "��!\n\n��ȸ�� 1�� ���ҽ��ϴ�!";
        gameText.color = new Color32(235, 83, 158, 255);

        yield return new WaitForSeconds(2f);

        gameLabel.SetActive(false); // ��Ȱ��ȭ
        gs = GameState.Run;
    }

    public void gameOver() // 3�� ���� => ���� ����
    {
        gameLabel.SetActive(true); // ���� �� �ؽ�Ʈ Ȱ��ȭ
        gameText.color = new Color32(237, 0, 109, 255);

        gameText.text = "Game Over\n\n����� ���� �����մϴ�...";

        gs = GameState.GameOver;

        StartCoroutine(EndToFail());
    }
    IEnumerator EndToFail()
    {
        yield return new WaitForSeconds(3f);

        gameText.text = "����...\n\n�ڸ��� ��� ��ġ��...";
        gameText.color = new Color32(42, 0, 102, 255);

        yield return new WaitForSeconds(3.5f);

        gameText.text = "~ �̵��� ~";
        gameText.color = new Color32(132, 90, 192, 255);

        yield return new WaitForSeconds(3f);

        gameText.text = "~ �̹� ���� �¸��Ա����Դϴ�  ~";

        yield return new WaitForSeconds(3f);

        gameText.text = "�� ���� ������...\n\n�����ϱ� ���� � ���߰ھ�.";
        gameText.color = new Color32(42, 0, 102, 255);

        yield return new WaitForSeconds(3.5f);

        gameText.text = "���� ������ �� �ǰ��� �� ����...\n\n���� �� ���� ������ �����ǳ�...";

        yield return new WaitForSeconds(4f);

        gameLabel.SetActive(false);
    }

    public void gameSuccess() // ���� ����
    {
        gameLabel.SetActive(true); // ���� �� �ؽ�Ʈ Ȱ��ȭ
        gameText.color = new Color32(161, 192, 90, 255);

        gameText.text = "����!\n\n�ɾƼ� ���� ����!";

        gs = GameState.Success;

        StartCoroutine(EndToSuccess());
    }
    IEnumerator EndToSuccess()
    {
        yield return new WaitForSeconds(3f);

        gameText.text = "�ѽ�! �� ��� ������!\n\n�ɾƼ� ������ ^_^";
        gameText.color = new Color32(42, 0, 102, 255);

        yield return new WaitForSeconds(3.5f);

        gameText.text = "~ �̵��� ~";
        gameText.color = new Color32(132, 90, 192, 255);

        yield return new WaitForSeconds(3f);

        gameText.text = "~ �̹� ���� �¸��Ա����Դϴ�  ~";

        yield return new WaitForSeconds(3f);

        gameText.text = "���� �� ������!\n\n�����ϱ� ���� � ���߰ھ�.";
        gameText.color = new Color32(42, 0, 102, 255);

        yield return new WaitForSeconds(3.5f);

        gameText.text = "�׷��� �ɾƼ� ������ �ξ� �� �ǰ��� �� ����.\n\n���� ���� �� ���� �ߵǰڴ�!\n\n���� ���� ������ ������ ����";

        yield return new WaitForSeconds(4f);

        gameLabel.SetActive(false);
    }
}
