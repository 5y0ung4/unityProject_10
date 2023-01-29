using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PRGameManager : MonoBehaviour
{
    public string[] questionarray= { "����1","����2","����3"};
    public string[] answerAarray= { "���a1","���a2","���a3"};
    public string[] answerBarray= { "���b1","���b2","���b3"};
    public string[] answerCarray= { "���c1","���c2","���c3"};

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
        
    
