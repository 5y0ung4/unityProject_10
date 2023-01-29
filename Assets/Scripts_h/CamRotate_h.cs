using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate_h : MonoBehaviour
{
    public float rotSpeed = 200f; // 회전 속도

    float mx = 0, my = 0; // 회전 값

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 입력 받기
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        // 회전 값 변수에 마우스 입력 값만큼 미리 누적
        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;

        // 마우스 상하 이동 회전 변수의 값 제한시키기
        my = Mathf.Clamp(my, -90f, 90f);

        // 회전 방향으로 물체 회전시키기
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
