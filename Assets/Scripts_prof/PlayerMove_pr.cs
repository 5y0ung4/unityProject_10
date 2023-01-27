using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_pr : MonoBehaviour
{
    public float moveSpeed = 1f;

    CharacterController cc;

    float gravity = -20f;

    float yVelocity = 0;
    
    // Start is called before the first frame update
    void Start()
    {
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
}
