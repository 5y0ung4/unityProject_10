using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_pr : MonoBehaviour
{
    public float moveSpeed = 1f;

    CharacterController cc;

    float gravity = -20f;

    float yVelocity = 0;

    public GameObject BeforeGame3Dpr;
    
    // Start is called before the first frame update
    void Start()
    {
        BeforeGame3Dpr.SetActive(false);
        Invoke("beforegame3d", 0.01f);
        Invoke("beforegameclose", 2.5f);
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        dir = Camera.main.transform.TransformDirection(dir);

        transform.position += dir * moveSpeed * Time.deltaTime;

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir*moveSpeed*Time.deltaTime);
    }

    public void beforegame3d()
    {
        BeforeGame3Dpr.SetActive(true);
    }

    public void beforegameclose()
    {
        BeforeGame3Dpr.SetActive(false);
    }
    
    //IEnumerator wait()
    //{
    //    yield return new WaitForSeconds(0.3f);

    //    BeforeGame3Dpr.SetActive(false);
    //}
}
