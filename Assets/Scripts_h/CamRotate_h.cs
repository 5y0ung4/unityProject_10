using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate_h : MonoBehaviour
{
    public float rotSpeed = 200f; // ȸ�� �ӵ�

    float mx = 0, my = 0; // ȸ�� ��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 �Է� �ޱ�
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        // ȸ�� �� ������ ���콺 �Է� ����ŭ �̸� ����
        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;

        // ���콺 ���� �̵� ȸ�� ������ �� ���ѽ�Ű��
        my = Mathf.Clamp(my, -90f, 90f);

        // ȸ�� �������� ��ü ȸ����Ű��
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
