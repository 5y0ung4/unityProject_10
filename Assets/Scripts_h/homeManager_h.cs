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

    int finalScore = SCScoreManager.Instance.WcurrentScore; // ���� ����

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

        if (finalScore > 0) // ���� ��ŸƮ�� �ƴ� �����̶��
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
        else // ������ ��ŸƮ
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
        getUpText.text = "��ħ�̴�!\n���� ���� �������� ������ ����� ���.";

        yield return new WaitForSeconds(3f);

        getUpText.text = "�Ϸ��� ������ ����!\n������ ���� �������� �Ϸ縦 �����߰ڴ�.";

        yield return new WaitForSeconds(3f);

        getUpText.text = "�ϴ� ���� �������� üũ����.\nå�� ���� �� ���̾�� ���߰ھ�.";

        yield return new WaitForSeconds(4f);

        background.SetActive(false);
        getUpText.color = new Color32(0, 0, 0, 255);
        getUpText.text = "å�� ���� ���� ���̾�� ã�� Ŭ���غ����� !";

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
        getUpText.text = "���̾ �����ֳ�.\n�������� ������ ������~~";

        yield return new WaitForSeconds(3f);

        background.SetActive(true);
        bg.color = new Color32(0, 0, 0, 247);
        getUpText.color = new Color32(255, 133, 202, 255);
        getUpText.text = "<�轴���� ���̾>\n2023.?.?\n\n1. 1-2���� ������ : 50�ֳ� ����\n" +
            "2. ���ɽð� : �����԰� �Ļ�&���\n3. 5-6���� ������ : ��2���а�";

        yield return new WaitForSeconds(7f);

        getUpText.color = new Color32(255, 255, 255, 255);
        getUpText.text = "�� ������ 1���� ������ �ִ� ���̰�~\n�� ������ ����� �����̾�����!\n" +
            "�׸��� ��2������ ������ �־���..";

        yield return new WaitForSeconds(4f);

        getUpText.text = "������ �� �ٻ� �Ϸ簡 �ǰڳ�!\n� ���� �غ� �ؾ߰ڴ�";

        yield return new WaitForSeconds(2.5f);

        getUpText.text = "~ ���� �غ��� ~";

        yield return new WaitForSeconds(2f);

        background.SetActive(false);
        getUpText.color = new Color32(0, 0, 0, 255);
        getUpText.text = "���� �б��� ������ �ð��Դϴ�!\n������ ���� ���� Ŭ���غ����� !";

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
        getUpText.text = "ö��!\n�ٳ���ڽ��ϴ�~";

        yield return new WaitForSeconds(2f);

        getUpText.text = "����ö Ÿ�� ���Կ����� ���� ��Ʋ Ÿ�߰ڴ�!\n7ȣ�� ��� ������?\n�ɾƼ� ���� ���ڴµ�~";
        nextBtn.SetActive(true);
    }

    public void NextMap_btn()
    {
        SceneManager.LoadScene("SceneNum0");
    }

    void worth() // �ѵ������ > �ǰ������
    {
        player.transform.position = chair.transform.position; // �÷��̾� �̵���Ű��

        ms = MorningState.Idle;
        StartCoroutine(writeDiary());
    }
    IEnumerator writeDiary()
    {
        yield return new WaitForSeconds(2.5f);

        background.SetActive(true);
        bg.color = new Color32(0, 0, 0, 247);
        ending.color = new Color32(255, 255, 255, 255);
        ending.text = "���õ� �Ϸ��� ���� �ٰ��Դ�.\n������ ���� ���� �������̾���.";

        yield return new WaitForSeconds(3f);

        ending.text = "�ֱٵ�� ���� �ѵ��� ���� �ٷ� ������ �� ����.\n�̷� ���� �ϱ⸦ �� �������!";

        yield return new WaitForSeconds(3f);

        ending.text = " ~ �ϱ� ���� �� ~";
        yield return new WaitForSeconds(2f);

        ending.text = "�� �� ���!\n���ð��� ���� �������� ���ڳ�~\n���ϵ� ������ ����!";

    }

    void tired() // �ǰ������ > �ѵ������
    {
        ms = MorningState.Idle;

        background.SetActive(true);
        bg.color = new Color32(0, 0, 0, 255);
        ending.color = new Color32(201, 0, 73, 255);
        ending.text = "Black Out\n\n�÷��̾�� �ǰ￡ ��� ������\n���� �������ڸ��� �����ع��Ƚ��ϴ�.";
    }
}
