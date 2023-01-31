using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SSceneM : MonoBehaviour
{
    public static int num = 0;
    //public static string[] sceneNames = new string[] { "SceneNum0", "Subway", "classroom", "profroom2D", "Maze" };
    string sceneName;


    // Start is called before the first frame update
    void Start()
    {
        num++;
        /*sceneName = sceneNames[num];*/ //scene �̸� ����
        sceneName = "SceneNum" + num;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Ű ����, ����
        {
            Destroy(GameObject.Find("ScObj").gameObject);
            SceneManager.LoadScene(sceneName);
        }
    }
}
