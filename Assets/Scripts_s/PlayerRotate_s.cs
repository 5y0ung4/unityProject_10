using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate_s : MonoBehaviour
{
    public float rotSpeed = 200f; // 회전 속도

    float mx = 0; // 회전 값

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 상태 제어
        if (GameManager_s.gm.gs != GameManager_s.GameState.Run)
        {
            return;
        }

        // 마우스 좌우 입력 받기
        float mouse_X = Input.GetAxis("Mouse X");

        // 회전 값 변수에 마우스 입력 값만큼 미리 누적
        mx += mouse_X * rotSpeed * Time.deltaTime;

        // 회전 방향으로 물체 회전시키기
        transform.eulerAngles = new Vector3(0, mx, 0);
    }
}
