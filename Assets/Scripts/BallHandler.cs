using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    BoxCollider2D grabRange;
    List<GameObject> grabbableBalls = new List<GameObject>();
    GameObject myBall;
    public float yeetForce;
    
    // Start is called before the first frame update
    void Start() {
        grabRange = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Ball") {
            grabbableBalls.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag == "Ball") {
            grabbableBalls.Remove(other.gameObject);
        }
    }

    // TODO place myball in a reasonable spot, not just where it is...

    void Update () {
        if (Input.GetKeyDown(KeyCode.G)) {
            if (myBall is null) {
                if (grabbableBalls.Count > 0) {
                    myBall = grabbableBalls[0];
                    grabbableBalls.Remove(myBall);
                    myBall.GetComponent<Rigidbody2D>().isKinematic = true;
                    myBall.GetComponent<CircleCollider2D>().enabled = false;
                    myBall.transform.SetParent(gameObject.transform.parent);
                }
            } else { // carrying a ball
                var ballRB = myBall.GetComponent<Rigidbody2D>();
                ballRB.isKinematic = false;
                myBall.transform.parent = null;
                myBall.GetComponent<CircleCollider2D>().enabled = true;
                ballRB.AddForce(new Vector2(0, yeetForce));
                myBall = null;
            }
        }
    }
}
