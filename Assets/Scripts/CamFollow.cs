using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; // 목표가 될 트랜스폼 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 카메라 위치를 목표 트랜스폼의 위치에 일치시키기
        transform.position = target.position;
    }
}
