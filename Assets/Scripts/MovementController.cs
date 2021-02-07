using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float speed = 5.0f, jumpSpeed = 5.0f;
    bool grounded;
    private Transform m_GroundCheck;                    // A position marking where to check if the player is grounded.
    [SerializeField] private LayerMask m_WhatIsGround;  // A mask determining what is ground to the character
    const float k_GroundedRadius = .01f;                 // Radius of the overlap circle to determine if grounded

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        m_GroundCheck = transform.Find("GroundCheck");
    }

    void OnCollisionEnter2D (Collision2D c) 
    {
        if (c.gameObject.tag == "Ground")
            grounded = true;
    }

    void OnCollisionExit2D (Collision2D c) 
    {
        if (c.gameObject.tag == "Ground")
            grounded = false;
    }

    void FixedUpdate () {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject != gameObject) {
                grounded = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // var y = Inpu;
        var v = rigidbody.velocity;
        v.x = Input.GetAxis("Horizontal") * speed;
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            v.y = v.y + jumpSpeed;
        }
        rigidbody.velocity = v;
    }
}
