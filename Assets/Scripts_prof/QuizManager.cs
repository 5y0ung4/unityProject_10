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

    public string Wintext= "휴~ 무사히 상담을 마쳤다. " + System.Environment.NewLine +
               "교수님 기분이 웬지 좋아보이시는걸? " + System.Environment.NewLine +
               "기분좋게 강의실에 갈 수 있겠다.";

    public string Losetext= "휴~ 무사히 상담을 마쳤다." + System.Environment.NewLine +
                    "교수님 기분이 안 좋아지신 것 같은데.." + System.Environment.NewLine +
                    "일단 강의실로 가자.";

    //private Text Wintext = "휴~ 무사히 상담을 마쳤다. " + System.Environment.NewLine +
    //           "교수님 기분이 웬지 좋아보이시는걸? " + System.Environment.NewLine +
    //           "기분좋게 강의실에 갈 수 있겠다.";

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
                Debug.Log("컴포넌트불러옴");
                Endgame.text = Wintext;
            }
            else

                Debug.Log("컴포넌트불러옴");
            Endgame.text = Losetext;
        }
            
    
    ///*else*/ if((GetComponent<Answer>().currentdegree) > 50)
    //{
    //    endGame.SetActive(true);
    //    Debug.Log("문제를 다 풀었습니다.");            



    //Endgame.text = "휴~ 무사히 상담을 마쳤다. " + System.Environment.NewLine +
    //  "교수님 기분이 웬지 좋아보이시는걸? " + System.Environment.NewLine +
    //  "기분좋게 강의실에 갈 수 있겠다.";









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

        Debug.Log("next함수호출");
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
