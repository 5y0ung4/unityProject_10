using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicePsg_s : MonoBehaviour
{
    public int chance = 3;

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

        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            // ���� ����
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            // ���̰� �ε��� ����� ���� �����ϴ� ���� hitInfo
            RaycastHit hitInfo = new RaycastHit();

            // ���� �߻� �� �ε��� ��ü�� ���� ��
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (chance > 0 && hitInfo.collider.gameObject.tag == "Off")
                {
                    print("����");
                    chance = -1;
                    GameManager_s.gm.gameSuccess();
                }
                else if (hitInfo.collider.gameObject.tag=="On")
                {
                    chance--;
                    if (chance == 2)
                    {
                        print("��! ��ȸ�� 2�� ���ҽ��ϴ�");
                        StartCoroutine(GameManager_s.gm.try1());
                    }
                    else if (chance == 1)
                    {
                        print("��! ��ȸ�� 1�� ���ҽ��ϴ�");
                        StartCoroutine(GameManager_s.gm.try2());
                    }
                    else if (chance == 0)
                    {
                        print("game over, ����� �ɾƼ� �� �� �����ϴ�");
                        GameManager_s.gm.gameOver();
                    }
                }
            }
        }
    }
}
