using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToGame : MonoBehaviour
{
    public void SceneChange()
    {
        //GameObject ScObj = GameObject.Find("ScObj").gameObject;

        //Destroy(ScObj);
        SceneManager.LoadScene("profroom2D");
    }
    // Start is called before the first frame update
   
}
