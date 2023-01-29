using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_h : MonoBehaviour
{
    public float moveSpeed = 7f; // �̵� �ӵ� ����

    CharacterController cc; // ĳ���� ��Ʈ�ѷ� ����

    float gravity = -20f; // �߷� ����
    float yVelocity = 0; // ���� �ӷ� ����

    public float jumpPower = 3f; // ������ ����
    public bool isJumping = false; // ���� ���� ����

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>(); // ĳ���� ��Ʈ�ѷ� ������Ʈ �޾ƿ���
    }

    // Update is called once per frame
    void Update()
    {
        // ����� �Է� �ޱ�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // �̵� ���� ����
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized; // ���� ���� ����

        // ���� ī�޶� �������� ���� ��ȯ (������ǥ -> ������ǥ, ���� Ʈ������ == ����ī�޶�)
        dir = Camera.main.transform.TransformDirection(dir);

        // �̵� �ӵ��� ���� �̵��ϱ�
        transform.position += dir * moveSpeed * Time.deltaTime;

        if (isJumping && cc.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;
            yVelocity = 0;
        }
        if (!isJumping && Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
            isJumping = true;
        }

        // ĳ������ ���� �ӵ��� �߷� �� ����
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        // �̵� �ӵ��� ���� �̵��ϱ�
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}
