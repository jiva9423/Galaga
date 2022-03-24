using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyBullet : MonoBehaviour
{
    Rigidbody rb;
    float speed;
    Vector3 dir;
    GameObject player;
    public GameObject[] explosion;
    // Start is called before the first frame update
    void Start()
    {

        MoveBullet(); // move bullet towards player
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeSelf) {
            rb.AddForce(dir * speed, ForceMode.VelocityChange);


            if (transform.position.z >= 100 && transform.position.y >= 60)
            {
                //Destroy(this.gameObject);
            }
        }
        
    }

    // move bullet toward player position.
    private void MoveBullet() {
        rb = GetComponent<Rigidbody>();
        speed = .25f;
        player = GameObject.FindGameObjectWithTag("Player");

        // check that there is actually a player to move towards.
        if (player.activeSelf)
        {
            dir = (player.transform.position - transform.position);
            dir = dir.normalized;
        }
    }


    // if bullet hits the player then bullet destroy itself and cause explosion
    private void OnTriggerEnter(Collider other)
    {
        int index = Random.Range(0, explosion.Length);
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject obj = Instantiate(explosion[index], gameObject.transform);
            obj.transform.parent = null;
            Destroy(this.gameObject);
        }
    }


    // if bullet hits the player then bullet destroy itself and cause explosion
    private void OnCollisionEnter(Collision collision)
    {
        int index = Random.Range(0, explosion.Length);
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject obj = Instantiate(explosion[index], gameObject.transform);
            Destroy(this.gameObject);
        }
    }
}
