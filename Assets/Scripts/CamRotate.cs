using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 200f;

    float mx = 0;
    float my = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (GameManager.gm.gState != GameManager.GameState.Run)
        //{
        //    return;
        //}

        float mouse_X = Input.GetAxis("Mouse X"); // -1 ~ 1까지
        float mouse_Y = Input.GetAxis("Mouse Y"); // -1 ~ 1까지 값

        //Vector3 dir = new Vector3(-Mouse_Y, Mouse_X, 0);
        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;

        //transform.eulerAngles += dir * rotSpeed * Time.deltaTime;

        //Vector3 rot = transform.eulerAngles;
        //rot.x = Mathf.Clamp(rot.x, -90f, 90f);
        my = Mathf.Clamp(my, -90f, 90f);

        //transform.eulerAngles = rot;
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
