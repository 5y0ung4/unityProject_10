using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect1 : MonoBehaviour
{
    private const string StartText = "왔니? 오느라 고생했다.";

    public Text labelStartText;
    public PrDialogue1 prologuedialogue1;

    IEnumerator Start()
    {
        prologuedialogue1.gameObject.SetActive(false);
        
        StartCoroutine(_typing());
        yield return new WaitForSeconds(2f);

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        prologuedialogue1.gameObject.SetActive(true);
    }

    private IEnumerator _typing()
    {
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < StartText.Length; i++)
        {
            labelStartText.text = StartText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
    }
    
    // Start is called before the first frame update
   
}
