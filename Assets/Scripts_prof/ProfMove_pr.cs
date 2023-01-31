using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ProfMove_pr : MonoBehaviour
{
    Vector3 destination = new Vector3(2, 1, -9);
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        Vector3 speed = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref speed, 0.1f);

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("profroom2D");
        }

    }
}
