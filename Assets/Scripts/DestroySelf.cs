using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DestroySelf : MonoBehaviourPunCallbacks
{
    public GameObject[] explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Destroy the Enemy Plane and explode
    private void OnTriggerEnter(Collider other)
    {
        
        int index = Random.Range(0,explosion.Length);
        if (!other.gameObject.CompareTag("EnemyBullet"))
        {
            //Debug.Log("crashed:" + other.gameObject.tag);
        }



        if (other.gameObject.CompareTag("PlayerBullet") || other.gameObject.CompareTag("Player")) {
            GameObject obj = Instantiate(explosion[index], gameObject.transform);
            obj.transform.parent = null;
            this.GetComponentInParent<EnemyCheck>().setFilled(false);
            //PhotonNetwork.Destroy(this.gameObject);
            Destroy(this.gameObject); 
        }
        
    }

    // Destroy the Enemy Plane and explode
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("EnemyBullet")) {
            //Debug.Log("crashed:" + collision.gameObject.tag);
        }
        //Debug.Log("crashed:" + collision.gameObject.tag);
        int index = Random.Range(0, explosion.Length);
        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Player")) {
                index = 2;
            }
            
            GameObject obj = Instantiate(explosion[index], gameObject.transform);
            obj.transform.parent = null;
            this.GetComponentInParent<EnemyCheck>().setFilled(false);
            //PhotonNetwork.Destroy(this.gameObject);
            Destroy(this.gameObject);
        }
        
    }


}
