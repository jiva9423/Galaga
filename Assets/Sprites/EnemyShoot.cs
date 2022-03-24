using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    GameObject player;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            if (player.activeSelf)
            {
                if (Time.time > nextFire)
                {
                    fireRate = Random.Range(.1f, 4f);
                    nextFire = Time.time + fireRate;
                    ShootAtPlayer();
                }
            }
        }
        
        
    }

    void ShootAtPlayer() {
        if (player.activeSelf) {
            GameObject bulletI = Instantiate(bullet);
            Vector3 pos = transform.position;
            pos.z -= .5f;
            bulletI.transform.position = pos;
        }
        
    }
}
