using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {

        MovePlayerPlane();
    }


    // this applies the movement to the plane based on the buttons pressed.
    public void MovePlayerPlane() {
        Vector3 dir = Vector3.forward;
        rb.AddForce(dir * speed, ForceMode.VelocityChange);


        if (transform.position.z >= 100 && transform.position.y >= 60)
        {
            Destroy(this.gameObject);
        }
    }


    // check if an enemy has collided with the player plane
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) {
            Destroy(this.gameObject);
        }
    }
}
