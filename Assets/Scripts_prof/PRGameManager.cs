using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PRGameManager : MonoBehaviour
{
    public string[] questionarray= { "질문1","질문2","질문3"};
    public string[] answerAarray= { "대답a1","대답a2","대답a3"};
    public string[] answerBarray= { "대답b1","대답b2","대답b3"};
    public string[] answerCarray= { "대답c1","대답c2","대답c3"};

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

    IEnumerator Dialogue() { yield return new WaitForSeconds(0.1f);
        GetComponent<ChoiceWindowRun>();
        yield return new WaitForSeconds(0.1f);
        GetComponent<PrDialogue1>();
        while (questionarray != null)
        {
            
            Text qtextUI = savewords;

        }
        //savewords = questionarray[0];
        
        }

    IEnumerator question2()
    {
        
        yield return new WaitForSeconds(0.1f);
        GetComponent<ChoiceWindowRun>();
    }
     
}
        
    
