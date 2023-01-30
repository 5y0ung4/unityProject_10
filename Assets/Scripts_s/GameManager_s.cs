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

        StartCoroutine(ReadyToRun()); // ���� �غ� -> ���� ����
    }

    IEnumerator ReadyToRun()
    {
        background.SetActive(true);

        gameText.color = new Color32(178, 204, 255, 255);
        gameText.text = "�� �����̳�..\n���� ���� ������...";

        yield return new WaitForSeconds(2.5f);

        gameText.text = "��..\n���� �� ���� ��� �տ� �� �־��!";

        yield return new WaitForSeconds(2.5f);

        background.SetActive(false);
        gameText.color = new Color32(93, 90, 192, 255);
        gameText.text = "�� ������ �°��� ã�ƺ�����!\n�غ�!";
        
        yield return new WaitForSeconds(2f); // 2�ʰ� ���

        gameText.text = "����!";

        yield return new WaitForSeconds(0.5f); // 0.5�ʰ� ���

        gameLabel.SetActive(false); // ���Ӷ� �ؽ�Ʈ ��Ȱ��ȭ
        click.SetActive(true);
        gs = GameState.Run;

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator try1() // 1�� �������� ��
    {
        gs = GameState.Ready;

        gameLabel.SetActive(true); // ���� �� �ؽ�Ʈ Ȱ��ȭ
        background.SetActive(true);
        click.SetActive(false);

        gameText.text = "��!\n��ȸ�� 2�� ���ҽ��ϴ�!";
        gameText.color = new Color32(235, 83, 158, 255);

        yield return new WaitForSeconds(2f);

        gameLabel.SetActive(false); // ��Ȱ��ȭ
        background.SetActive(false);
        click.SetActive(true);
        gs = GameState.Run;
    }

    public IEnumerator try2() // 2�� �������� ��
    {
        gs = GameState.Ready;

        gameLabel.SetActive(true); // ���� �� �ؽ�Ʈ Ȱ��ȭ
        background.SetActive(true);
        click.SetActive(false);
        gameText.text = "��!\n��ȸ�� 1�� ���ҽ��ϴ�!";
        gameText.color = new Color32(235, 83, 158, 255);

        yield return new WaitForSeconds(2f);

        gameLabel.SetActive(false); // ��Ȱ��ȭ
        background.SetActive(false);
        click.SetActive(true);
        gs = GameState.Run;
    }

    public void gameOver() // 3�� ���� => ���� ����
    {
        gameLabel.SetActive(true); // ���� �� �ؽ�Ʈ Ȱ��ȭ
        background.SetActive(true);
        click.SetActive(false);
        gameText.color = new Color32(237, 0, 109, 255);

        gameText.text = "Game Over\n����� ���� ���߰ڳ׿�...";

        gs = GameState.Fail;

        StartCoroutine(EndToFail());
    }
    IEnumerator EndToFail()
    {
        yield return new WaitForSeconds(3f);

        background.SetActive(true);
        gameText.text = "����...\n�ڸ��� ��� ��ġ��...";
        gameText.color = new Color32(178, 204, 255, 255);

        yield return new WaitForSeconds(3.5f);

        gameText.text = "~ �̵��� ~";
        gameText.color = new Color32(181, 178, 255, 255);

        yield return new WaitForSeconds(3f);

        gameText.text = "~ �̹� ���� �¸��Ա����Դϴ�  ~";

        yield return new WaitForSeconds(3f);

        gameText.text = "�� ���� ������...\n�����ϱ� ���� � ���߰ھ�.";
        gameText.color = new Color32(178, 204, 255, 255);

        yield return new WaitForSeconds(3.5f);

        gameText.text = "���� ������ �� �ǰ��� �� ����...\n���� �� ���� ������ �����ǳ�...";

        yield return new WaitForSeconds(3.5f);

        gameText.text = "���콺 ������ ��ư�� ������\n���� ���ھ� Ȯ�� ����!";
        gameText.color = new Color32(181, 178, 255, 255);
    }

    public void gameSuccess() // ���� ����
    {
        background.SetActive(true);
        gameLabel.SetActive(true); // ���� �� �ؽ�Ʈ Ȱ��ȭ
        click.SetActive(false);
        gameText.color = new Color32(161, 192, 90, 255);

        gameText.text = "����!\n�ɾƼ� ���� ����!";

        gs = GameState.Success;

        StartCoroutine(EndToSuccess());
    }
    IEnumerator EndToSuccess()
    {
        yield return new WaitForSeconds(3f);

        gameText.text = "�ѽ�! �� ��� ������!\n�ɾƼ� ������ ^_^";
        gameText.color = new Color32(178, 204, 255, 255);

        yield return new WaitForSeconds(3.5f);

        gameText.text = "~ �̵��� ~";
        gameText.color = new Color32(181, 178, 255, 255);

        yield return new WaitForSeconds(3f);

        gameText.text = "~ �̹� ���� �¸��Ա����Դϴ�  ~";

        yield return new WaitForSeconds(3f);

        gameText.text = "���� �� ������!\n���� �غ� �ؾ���";
        gameText.color = new Color32(178, 204, 255, 255);

        yield return new WaitForSeconds(3.5f);

        gameText.text = "�׷��� �ɾƼ� ������ �ξ� �� �ǰ��� �� ����.\n����� ���� ���� ���� �� �ְڴ�!";

        yield return new WaitForSeconds(4f);

        gameText.text = "���콺 ������ ��ư�� ������\n���� ���ھ� Ȯ�� ����!";
        gameText.color = new Color32(181, 178, 255, 255);
    }

}
