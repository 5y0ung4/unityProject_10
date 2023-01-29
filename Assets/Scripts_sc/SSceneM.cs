using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SSceneM : MonoBehaviour
{
    public static int num = 0;
    public static string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        num++;
        sceneName = "SampleScene" + num; //scene �̸� ����
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Ű ����, ����
        {
            Destroy(GameObject.Find("ScObj").gameObject);
            SceneManager.LoadScene(sceneName);
        }
    }
}
