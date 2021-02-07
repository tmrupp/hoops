using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float speed = 5.0f, jumpSpeed = 5.0f;
    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D (Collision2D c) 
    {
        Debug.Log("entered a collider, tag=" + c.gameObject.tag + " go=" + c.gameObject.ToString());
        if (c.gameObject.tag == "Ground")
            grounded = true;
    }

    void OnCollisionExit2D (Collision2D c) 
    {
        Debug.Log("left a collider, tag=" + c.gameObject.tag);
        if (c.gameObject.tag == "Ground")
            grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        // var y = Inpu;
        var v = rigidbody.velocity;
        v.x = Input.GetAxis("Horizontal") * speed;
        if (grounded && Input.GetKeyDown(KeyCode.Space)) {
            v.y = v.y + jumpSpeed;
        }
        rigidbody.velocity = v;
    }
}
