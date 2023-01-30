using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        Run
    }
    public GameState gs;

    public GameObject gameLabel;
    Text gameText;

    public GameObject background;
    Image bg;

    public GameObject nextBtn;
    Button nb;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameState.Ready;

        gameText = gameLabel.GetComponent<Text>();
        bg = background.GetComponent<Image>();
        nb = nextBtn.GetComponent<Button>();

        nextBtn.SetActive(false);

        StartCoroutine(ReadyToRun()); // ���� �غ� -> ���� ����
    }

    IEnumerator ReadyToRun()
    {
        background.SetActive(true);

        gameText.color = new Color32(178, 204, 255, 255);
        gameText.text = "�� �����̳�..\n���� ���� ������...";

        yield return new WaitForSeconds(2.5f);

        gameText.text = "��..\n���� �� ���� ��� �տ� ���־��!";

        yield return new WaitForSeconds(2.5f);

        background.SetActive(false);
        gameText.color = new Color32(93, 90, 192, 255);
        gameText.text = "�� ������ �°��� ã�ƺ�����!\n�غ�!";
        
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
        gs = GameState.Ready;

        gameLabel.SetActive(true); // ���� �� �ؽ�Ʈ Ȱ��ȭ
        background.SetActive(true);

        gameText.text = "��!\n��ȸ�� 2�� ���ҽ��ϴ�!";
        gameText.color = new Color32(235, 83, 158, 255);

        yield return new WaitForSeconds(2f);

        gameLabel.SetActive(false); // ��Ȱ��ȭ
        background.SetActive(false);
        gs = GameState.Run;
    }

    public IEnumerator try2() // 2�� �������� ��
    {
        gs = GameState.Ready;

        gameLabel.SetActive(true); // ���� �� �ؽ�Ʈ Ȱ��ȭ
        background.SetActive(true);
        gameText.text = "��!\n��ȸ�� 1�� ���ҽ��ϴ�!";
        gameText.color = new Color32(235, 83, 158, 255);

        yield return new WaitForSeconds(2f);

        gameLabel.SetActive(false); // ��Ȱ��ȭ
        background.SetActive(false);
        gs = GameState.Run;
    }

    public void gameOver() // 3�� ���� => ���� ����
    {
        gameLabel.SetActive(true); // ���� �� �ؽ�Ʈ Ȱ��ȭ
        background.SetActive(true);
        gameText.color = new Color32(237, 0, 109, 255);

        gameText.text = "Game Over\n����� ���� �����մϴ�...";

        gs = GameState.Ready;

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

        gameText.text = "���� �ǰ���... \n�б��� ����..";
        nextBtn.SetActive(true);
    }

    public void gameSuccess() // ���� ����
    {
        background.SetActive(true);
        gameLabel.SetActive(true); // ���� �� �ؽ�Ʈ Ȱ��ȭ
        gameText.color = new Color32(161, 192, 90, 255);

        gameText.text = "����!\n�ɾƼ� ���� ����!";

        gs = GameState.Ready;

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

        gameText.text = "���� �� ������!\n���� �غ� �ؾ���.";
        gameText.color = new Color32(178, 204, 255, 255);

        yield return new WaitForSeconds(3.5f);

        gameText.text = "�׷��� �ɾƼ� ������ �ξ� �� �ǰ��� �� ����.\n���� ���� �� ���� �ߵǰڴ�!\n���� ���� ������ ������ ����";

        yield return new WaitForSeconds(4f);

        gameText.text = "���~\n�б� ���� �߰����� ������ ��.��";
        nextBtn.SetActive(true);
    }

    public void nextMap_btn()
    {
        SceneManager.LoadScene("classroom");
    }
}
