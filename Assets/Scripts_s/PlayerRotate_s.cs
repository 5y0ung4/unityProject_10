using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate_s : MonoBehaviour
{
    public float rotSpeed = 200f; // ȸ�� �ӵ�

    float mx = 0; // ȸ�� ��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���� ����
        if (GameManager_s.gm.gs != GameManager_s.GameState.Run)
        {
            return;
        }

        // ���콺 �¿� �Է� �ޱ�
        float mouse_X = Input.GetAxis("Mouse X");

        // ȸ�� �� ������ ���콺 �Է� ����ŭ �̸� ����
        mx += mouse_X * rotSpeed * Time.deltaTime;

        // ȸ�� �������� ��ü ȸ����Ű��
        transform.eulerAngles = new Vector3(0, mx, 0);
    }
}
