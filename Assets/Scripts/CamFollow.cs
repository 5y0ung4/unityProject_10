using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; // ��ǥ�� �� Ʈ������ �����Ʈ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ī�޶� �ġ�� ��ǥ Ʈ�������� �ġ�� ��ġ��Ű��
        transform.position = target.position;
    }
}
