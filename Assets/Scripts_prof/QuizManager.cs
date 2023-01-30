using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    
    public List<QuestionAndAnswer> qna;

    public GameObject[] options;

    public int currentQuestion;

    public Text QuestionText;

    public Text Endgame;

    public int i;

    public GameObject endGame;

    public string Wintext= "��~ ������ ����� ���ƴ�. " + System.Environment.NewLine +
               "������ ����� ���� ���ƺ��̽ô°�? " + System.Environment.NewLine +
               "������� ���ǽǿ� �� �� �ְڴ�.";

    public string Losetext= "��~ ������ ����� ���ƴ�." + System.Environment.NewLine +
                    "������ ����� �� �������� �� ������.." + System.Environment.NewLine +
                    "�ϴ� ���ǽǷ� ����.";

    //private Text Wintext = "��~ ������ ����� ���ƴ�. " + System.Environment.NewLine +
    //           "������ ����� ���� ���ƺ��̽ô°�? " + System.Environment.NewLine +
    //           "������� ���ǽǿ� �� �� �ְڴ�.";

    //public string endgameText;
    // Start is called before the first frame update
    void Start()
    {
        
        endGame.SetActive(false);
        makeQuestion();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void makeQuestion()
    {
        GetComponent<Answer>();
        if (qna.Count >=1)
        {
         currentQuestion = Random.Range(0, qna.Count);

            QuestionText.text = qna[currentQuestion].question;

            setAnswer();
        }
        else
        {
            endGame.SetActive(true);
            if ((GetComponent<Answer>().currentdegree) >= 50)
            {
                Debug.Log("������Ʈ�ҷ���");
                Endgame.text = Wintext;
            }
            else

                Debug.Log("������Ʈ�ҷ���");
            Endgame.text = Losetext;
        }
            
    
    ///*else*/ if((GetComponent<Answer>().currentdegree) > 50)
    //{
    //    endGame.SetActive(true);
    //    Debug.Log("������ �� Ǯ�����ϴ�.");            



    //Endgame.text = "��~ ������ ����� ���ƴ�. " + System.Environment.NewLine +
    //  "������ ����� ���� ���ƺ��̽ô°�? " + System.Environment.NewLine +
    //  "������� ���ǽǿ� �� �� �ְڴ�.";









}


    void setAnswer()
    {
        for(int i = 0; i < options.Length; i++)
        {
            //options[i].GetComponent<Text>().text=
            //options[i].GetComponent<Answer>().iswrong = false;
            //options[i].transform.GetChild(0).GetComponent<Text>().text = qna[i].Answers[i];
            options[i].transform.GetChild(0).GetComponent<Text>().text = qna[currentQuestion].Answers[i];

            if (qna[i].correctAnswer == i + 1)
            {
                options[i].GetComponent<Answer>().isCorrect = true;
            }
        }
    }

    public void Next()
    {
        qna.RemoveAt(currentQuestion);

        makeQuestion();

        //ChoiceWindowRun();
        //GetComponent<ChoiceWindowRun>().OnMouseDown();

        Debug.Log("next�Լ�ȣ��");
    }

    //public void ChoiceWindowRun()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        ChoiceWindow1.SetActive(true);
    //    }
    //    else
    //        ChoiceWindow1.SetActive(false);
    //}
}
