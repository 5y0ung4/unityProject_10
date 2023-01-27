using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text tx;
    private string m_text = "왔니? 오느라 고생했다.";

    public GameObject StartTalk;
    
    // Start is called before the first frame update
    public void Start()
    {
        

        if (Input.GetButtonUp("ButtonG")==true)
        {
            gameObject.SetActive(true);

            StartCoroutine(_typing());
        }
        else
            return;
        
       
    }
IEnumerator _typing()
    {
       

        for (int i = 0; i <= m_text.Length; i++)
        {
            tx.text = m_text.Substring(0,i);

            yield return new WaitForSeconds(0.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
