using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Answer answer;
    public Slider ldslider;

    public List<QuestionAndAnswer> qna;

    public GameObject[] options;

    public int currentQuestion;

    public Text QuestionText;

    public Text Endgame;

    public int i;

    public GameObject endGame;

    public GameObject good;

    public GameObject bad;


    

    public string[] endText = 
        {"��~ ������ ����� ���ƴ�. " + System.Environment.NewLine +
               "������ ����� ���� ���ƺ��̽ô°�? " + System.Environment.NewLine +
               "������� ���ǽǿ� �� �� �ְڴ�.",

        "��~ ������ ����� ���ƴ�." + System.Environment.NewLine +
                    "������ ����� �� �������� �� ������.." + System.Environment.NewLine +
                    "�ϴ� ���ǽǷ� ����."};

    //public AudioClip audio;

    // Start is called before the first frame update
    void Start()
    {
        
        endGame.SetActive(false);

        good.SetActive(false);

        bad.SetActive(false);


    makeQuestion();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void makeQuestion()
    {
        
        if (qna.Count >0)
        {
        currentQuestion = Random.Range(0, qna.Count);

        QuestionText.text = qna[currentQuestion].question;


        setAnswer();
        }
        else
        {
            endGame.SetActive(true);

            if (ldslider.value > 30)
            {
                Debug.Log("������Ʈ1�ҷ���");
                Endgame.text = endText[0];
                //Debug.Log(endText[0]);
            }
            else
            {
                Debug.Log("������Ʈ2�ҷ���");
                //Debug.Log(endText[1]);
                Endgame.text = endText[1];
                //Endgame.text = endText[1];
            }

                
        }

    }


    void setAnswer()
    {
        for(int i = 0; i < options.Length; i++)
        {
            //options[i].GetComponent<Text>().text=
            //options[i].GetComponent<Answer>().iswrong = false;
            //options[i].transform.GetChild(0).GetComponent<Text>().text = qna[i].Answers[i];
            
           options[i].transform.GetChild(0).GetComponent<Text>().text = qna[currentQuestion].Answers[i];

            if (qna[i].correctAnswer == i)
            {
                options[i].GetComponent<Answer>().isCorrect = true;
            }
        }
    }

    public void Next()
    {
        good.SetActive(false);
        bad.SetActive(false);
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

    public void Good()
    {
        good.SetActive(true);
    }
}
