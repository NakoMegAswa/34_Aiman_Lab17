﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public int healthCount;
    public int coinCount;

    private Rigidbody2D rb;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hVelocity = 0;
        float vVelocity = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hVelocity = -moveSpeed;
            transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            hVelocity = moveSpeed;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            vVelocity = jumpForce;
            animator.SetTrigger("JumpTrigger");
        }

        hVelocity = Mathf.Clamp(rb.velocity.x + hVelocity, -5, 5);

        rb.velocity = new Vector2(hVelocity, rb.velocity.y + vVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mace")
        {
            healthCount -= 10;
        }
    }
}
