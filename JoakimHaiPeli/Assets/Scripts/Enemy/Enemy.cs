using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentSpeed = 3f;
    public Transform playerTransform;
    private Rigidbody2D body;
    private Vector2 direction;

    void Awake(){
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {

        if(playerTransform == null)
        { 
            return; 

        }
        direction = (playerTransform.position - transform.position).normalized;
        body.MovePosition(body.position + direction * currentSpeed * Time.fixedDeltaTime);
        }
}


