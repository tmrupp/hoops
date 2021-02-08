using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGrabber : MonoBehaviour
{   
    public Transform grabDetect;
    public Transform ballHolder;
    public float rayDist;
   

    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        if(grabCheck.collider != null && grabCheck.collider.tag == "Circle Collider 2D");
        {
            if(Input.GetKey(KeyCode.G))
            {
                grabCheck.collider.gameObject.transform.parent = ballHolder;
                grabCheck.collider.gameObject.transform.position = ballHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
             }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }
}
