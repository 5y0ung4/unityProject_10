using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return
    }

    EnemyState m_State;

    public float findDistance = 8f;
    public float attackDistance = 2f;
    public float moveSpeed = 5f;

    Transform player;

    CharacterController cc;

    float currentTime = 0; //누적시간
    float attackDelay = 2f;

    public int attackPower = 3;

    Vector3 originPos;
    Quaternion originRot;

    public float moveDistance = 20f;

    //Animator anim;

    NavMeshAgent smith;

    // Start is called before the first frame update
    void Start()
    {
        m_State = EnemyState.Idle;

        player = GameObject.Find("Player").transform;

        cc = GetComponent<CharacterController>();

        originPos = transform.position;
        originRot = transform.rotation;

        //anim = transform.GetComponentInChildren<Animator>();

        smith = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;

            case EnemyState.Move:
                Move();
                break;

            case EnemyState.Attack:
                Attack();
                break;

            case EnemyState.Return:
                Return();
                break;

        }

    }

    void Idle()
    {
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            m_State = EnemyState.Move;
            print("상태 전환이 Idle -> Move");

            //anim.SetTrigger("IdleToMove");
        }
    }

    void Move()
    {
        if (Vector3.Distance(transform.position, player.position) > moveDistance)
        {
            m_State = EnemyState.Return;
            print("상태 전환이 Move -> Return");
        }
        else if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {//거리가 2~8사이
            //Vector3 dir = (player.position - transform.position).normalized;

            //cc.Move(dir * moveSpeed * Time.deltaTime);

            //transform.forward = dir;

            //smith.isStopped = true;
            //smith.ResetPath();

            //smith.destination = player.position;
            //smith.stoppingDistance = attackDistance;

        }
        else
        {
            m_State = EnemyState.Attack;
            print("상태 전환이 Move -> Attack");

            currentTime = attackDelay;
            //anim.SetTrigger("MoveToAttackDelay");
        }
    }

    void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                print("공격");

                //player.GetComponent<PlayerMove>().DamageAction(attackPower);

                currentTime = 0;

                //anim.SetTrigger("StartAttack");
            }
        }
        else
        {
            m_State = EnemyState.Move;
            print("상태 전환이 Attack -> Move");
            currentTime = attackDelay;

            //anim.SetTrigger("AttackToMove");
        }
    }

    void Return()
    {
        if (Vector3.Distance(transform.position, originPos) > 0.1f)
        {
            //Vector3 dir = (originPos - transform.position).normalized;
            //cc.Move(dir * moveSpeed * Time.deltaTime);

            //transform.forward = dir;

            //smith.destination = originPos;
            //smith.stoppingDistance = 0;


        }
        else
        {
            smith.isStopped = true;
            smith.ResetPath();

            transform.position = originPos;
            transform.rotation = originRot;

            m_State = EnemyState.Idle;
            print("상태 전환이 Return -> Idle");

            //anim.SetTrigger("MoveToIdle");
        }
    }


}
