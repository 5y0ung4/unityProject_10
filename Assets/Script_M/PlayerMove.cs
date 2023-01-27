using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;

    CharacterController cc;

    float gravity = -20f;

    public float yVelocity = 0;

    public float jumpPower = 5f;

    public bool isJumping = false;

    public float time = 60;

    int maxTime = 60;

    public Slider TimeSlider;

    //public Collision box;

    //public GameObject hitEffect;

    //Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();

        //anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        //anim.SetFloat("MoveMotion", dir.magnitude);


        dir = Camera.main.transform.TransformDirection(dir); //로컬 기준

        //transform.position += dir * moveSpeed * Time.deltaTime;

        if (isJumping && cc.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;
            yVelocity = 0;
        }

        //if (Input.GetButtonDown("Jump") && !isJumping)
        if (!isJumping && Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
            isJumping = true;
        }

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime);

        TimeSlider.value = (float)time / maxTime;

        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Finish"))
        {
            GameManager.gm.gState = GameManager.GameState.Success;
        }

        else if (collision.collider.gameObject.CompareTag("Cat"))
        {
            GameManager.gm.gState = GameManager.GameState.Cat;
        }

        else if (collision.collider.gameObject.CompareTag("Pseudo"))
        {
            GameManager.gm.gState = GameManager.GameState.Pseudo;
        }

        else if (collision.collider.gameObject.CompareTag("Wall"))
        {
            GameManager.gm.gState = GameManager.GameState.Breakaway;
        }

        else if (collision.collider.gameObject.CompareTag("OtherBox"))
        {
            GameManager.gm.gState = GameManager.GameState.Misunderstand;
        }
    }

    //public void DamageAction(int damage)
    //{
    //    hp -= damage;
    //    //print("플레이어 체력: " + hp);

    //    if (hp > 0)
    //    {
    //        StartCoroutine(PlayHitEffect());
    //    }
    //}

    //IEnumerator PlayHitEffect()
    //{
    //    hitEffect.SetActive(true);

    //    yield return new WaitForSeconds(0.3f);

    //    hitEffect.SetActive(false);
    //}
}
