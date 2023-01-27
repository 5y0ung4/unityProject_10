using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerMove : MonoBehaviour
{
    public float speed = 5;

    public int score = 50;
    int maxScore = 100;

    public Slider scoreSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CGameManager.gm.gState != CGameManager.GameState.Run)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, 0);

        transform.position += dir * speed * Time.deltaTime;

        scoreSlider.value = (float)score / (float)maxScore;
    }
}
