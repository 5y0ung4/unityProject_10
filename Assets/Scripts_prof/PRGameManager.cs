using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PRGameManager : MonoBehaviour
{
    public string[] qarray = {
        "���� ������ ���� �����?",
        "���� �����ϴ� ������?",
        "���� ����ϴ� ��������?",
        "���� �����ϴ� ������?",
        "���� �� �ϰ� ���� ����?",
        "���� �Ⱦ��ϴ� ����?",
        "���� ������?",
        "���� ��������?",
        "���� ���� ���ϴ� ����?",
        "���� ���� ������ �� �� ����������?"
    };
    public string[] Aarray = { "����Ʈ", "������", "����", "����ȫ��", "��������", "���", "30��", "AB��", "����������", "0��" };
    public string[] Barray = { "�״�����", "��â����", "����", "����", "����", "����", "17��", "O��", "�ϻ�", "1��" };
    public string[] Carray = { "���þ�", "����� ", "Ź��", "������ ", "�޴��� �ٲٱ�", "�߱�", "25��", "A��", "�޸���", "2��" };

    public int i;

    public Text qtextUI;
    public Text savewords;

    public Text atextUI;
    public Text btextUI;
    public Text ctextUI;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TypingEffect1>()._typing();
    }



    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Dialogue());
    }

    IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<ChoiceWindowRun>();
        yield return new WaitForSeconds(0.1f);
        GetComponent<PrDialogue1>();
        while (qarray != null)
        {

            Text qtextUI = savewords;

        }
        for (i = 0; i < qarray.Length; i++)
        {
            qtextUI.text = qarray[i];

        }
        StartCoroutine(question2());
    }

    IEnumerator question2()
    {
        
        yield return new WaitForSeconds(0.1f);
        GetComponent<ChoiceWindowRun>();
    }
     
}
        
    
