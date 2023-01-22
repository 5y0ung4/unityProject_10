using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2NoteMove : MonoBehaviour
{
    public float speed = 12f;

    Rigidbody2D rbody;
    
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        if (S2GameManager.gm.gState != S2GameManager.GameState.Run)
        {
            return;
        }

        rbody.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = -speed;
        //this.GetComponent<SpriteRenderer>().flipX = (speed < 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
