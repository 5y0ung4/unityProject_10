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
        getUpText.text = "���̾ �����ֳ�.\n�������� ������ ������~~";

        yield return new WaitForSeconds(3f);

        background.SetActive(true);
        bg.color = new Color32(0, 0, 0, 247);
        getUpText.color = new Color32(255, 133, 202, 255);
        getUpText.text = "<�轴���� ���̾>\n2023.?.?\n\n1. 1-2���� ������ : 50�ֳ� ����\n" +
            "2. ���ɽð� : �����԰� �Ļ�&���\n3. 5-6���� ������ in ��2���а�";

        yield return new WaitForSeconds(7f);

        getUpText.color = new Color32(255, 255, 255, 255);
        getUpText.text = "�� ������ 1���� ������ �ִ� ���̰�~\n�� ������ ����� �����̾�����!\n" +
            "�׸��� ��2������ ������ �־���..";

        yield return new WaitForSeconds(4f);

        getUpText.text = "������ �� �ٻ� �Ϸ簡 �ǰھ�!\n� ���� �غ� �ؾ���.";

        yield return new WaitForSeconds(2f);

        getUpText.text = "~ ���� �غ��� ~";

        yield return new WaitForSeconds(2f);

        background.SetActive(false);
        getUpText.color = new Color32(0, 0, 0, 255);
        getUpText.text = "���� �б��� ������ �ð��Դϴ�!\n������ ���� ���� Ŭ���غ����� !";

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
        getUpText.text = "ö��!\n�ٳ���ڽ��ϴ�~";

        yield return new WaitForSeconds(2f);

        getUpText.text = "����ö Ÿ�� ���Կ����� ���� ��Ʋ Ÿ�߰ڴ�!\n7ȣ�� ��� ������?\n�ɾƼ� ���� ���ڴµ�~";
        nextBtn.SetActive(true);
    }

    public void NextMap_btn()
    {
        SceneManager.LoadScene("Subway");
    }
}
