using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    //public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 키 변경, 설명
        {
            SceneManager.LoadScene("Score");
        }
    }

    public void ButtonClick()
    {
        SceneManager.LoadScene("Score");
    }
}
