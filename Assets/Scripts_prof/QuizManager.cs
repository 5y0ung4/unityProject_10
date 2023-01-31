using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
   // public Answer answer;
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

    public int likedegree = 10;

    public int mxlikedegree = 100;

    public int currentdegree;

    public GameObject an;
    Answer answer;


    public string[] endText = 
        {"게임 클리어!"+ System.Environment.NewLine + "휴~ 무사히 상담을 마쳤다. " + System.Environment.NewLine +
               "교수님 기분이 웬지 좋아보이시는걸? " + System.Environment.NewLine +
               "기분좋게 강의실에 갈 수 있겠다." ,

        "게임 오버!" + System.Environment.NewLine + "휴~ 무사히 상담을 마쳤다." + System.Environment.NewLine +
                    "교수님 기분이 안 좋아지신 것 같은데.." + System.Environment.NewLine +
                    "일단 수업을 들어야하니 강의실로 가자." };

    //public AudioClip audio;

    // Start is called before the first frame update
    void Start()
    {
        
        endGame.SetActive(false);

        if(good.activeSelf && bad.activeSelf)
        {
            good.SetActive(false);

            bad.SetActive(false);
        }
        


    makeQuestion();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void makeQuestion()
    {
        answer = an.GetComponent<Answer>();
        if (qna.Count > 0)
        {
            currentQuestion = Random.Range(0, qna.Count);
            QuestionText.text = qna[currentQuestion].question;
            setAnswer();
        }
        else
        {
            //an = an.GetComponent<Answer>();

            if ((currentdegree) >= 50)
            {
                Invoke("WinGame", 2.5f);
                Debug.Log(endText[0]);
            }
            else
            {
                Invoke("LoseGame", 2.5f);
                Debug.Log(endText[1]);

                //Endgame.text = endText[1];
            }
        }

           

                
        

    }


    void setAnswer()
    {
        //for(int i = 0; i <= options.Length; i++)
        //{
        //    //options[i].GetComponent<Text>().text=
        //    //options[i].GetComponent<Answer>().iswrong = false;
        //    //options[i].transform.GetChild(0).GetComponent<Text>().text = qna[i].Answers[i];
        //   options[i].GetComponent<Answer>().isCorrect = false; 
        //   options[i].transform.GetChild(0).GetComponent<Text>().text = qna[currentQuestion].Answers[i];
        //    //options[i].transform.Find("ButtonA").GetComponent<Text>().text = qna[currentQuestion].Answers[i];

        //    //options[i].GetComponent<Answer>().isCorrect = true;

        //    if (qna[currentQuestion].correctAnswer == i)
        //    {
        //        options[i].GetComponent<Answer>().isCorrect = true;
        //    }
        //}

        foreach(GameObject go in options)
        {
            go.GetComponent<Answer>().isCorrect = false;
            go.transform.GetChild(0).GetComponent<Text>().text = qna[currentQuestion].Answers[i++];
            
            if (qna[currentQuestion].correctAnswer == i)
            {
                go.GetComponent<Answer>().isCorrect = true;
            }
        }
    }

    public void Next()
    {
        i = 0;
        good.SetActive(false);
        bad.SetActive(false);
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

    public void Good()
    {
        good.SetActive(true);
    }

    public void WinGame()
    {
        Debug.Log("컴포넌트1불러옴");
        endGame.SetActive(true);
        Endgame.text = endText[0];
    }

    public void LoseGame()
    {
        Debug.Log("컴포넌트2불러옴");
        endGame.SetActive(true);
        //Debug.Log(endText[1]);
        Endgame.text = endText[1];
    }
}
