using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2DestroyZone : MonoBehaviour
{
    //public bool flag = false;
    //public float destroyDistance = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if ((Vector2.Distance(GameObject.Find("Note").transform.position, transform.position) >= destroyDistance)
        //    && Input.GetMouseButtonDown(0))
        //{
        //    Hit();
        //}

        //    if (flag == true && Input.GetMouseButtonDown(0))
        //{
        //    Enter();
        //    Hit();
        //}
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //flag = true;
        if (Input.GetMouseButtonDown(0))
            Hit();
    }

    private void Hit()
    {
        Destroy(GameObject.Find("Note"));
    }

    //private void Enter()
    //{
    //    //Vector3 hitDistance = GameObject.Find("Note").transform.position - transform.position;

    //    if (Vector3.Distance(GameObject.Find("Note").transform.position, transform.position)
    //        <= destroyDistance)
    //    {
    //        flag = true;
    //    }
    //    else
    //    {
    //        flag = false;
    //    }
    //}
}
