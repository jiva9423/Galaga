using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    bool invincible = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // check if we are hit by the enemy planes bullets
    // if hit make ourselves invincible for a few seconds
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet") && !invincible) {
            if (GameData.lives == 0) {
                this.gameObject.SetActive(false);
                GameData.dead = true;

            } else if (GameData.lives != 0) {
                GameData.lives -= 1;
            }

            if (this.gameObject.activeSelf) {
               StartCoroutine(MakeInvincible());
            }
            
        }
    }

    // timer for invincibility
    IEnumerator MakeInvincible() {
        invincible = true;
        yield return new WaitForSecondsRealtime(1);
        invincible = false;
    }
}
