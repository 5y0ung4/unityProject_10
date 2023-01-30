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
        // 게임 상태 제어
        if (GameManager_s.gm.gs != GameManager_s.GameState.Run)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            // 레이 생성
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            // 레이가 부딪힌 대상의 정보 저장하는 변수 hitInfo
            RaycastHit hitInfo = new RaycastHit();

            // 레이 발사 후 부딪힌 물체가 있을 때
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (chance > 0 && hitInfo.collider.gameObject.tag == "Off")
                {
                    print("정답");
                    chance = -1;
                    GameManager_s.gm.gameSuccess();
                }
                else if (hitInfo.collider.gameObject.tag=="On")
                {
                    chance--;
                    if (chance == 2)
                    {
                        print("땡! 기회가 2번 남았습니다");
                        StartCoroutine(GameManager_s.gm.try1());
                    }
                    else if (chance == 1)
                    {
                        print("땡! 기회가 1번 남았습니다");
                        StartCoroutine(GameManager_s.gm.try2());
                    }
                    else if (chance == 0)
                    {
                        print("game over, 당신은 앉아서 갈 수 없습니다");
                        GameManager_s.gm.gameOver();
                    }
                }
            }
        }
    }
}
