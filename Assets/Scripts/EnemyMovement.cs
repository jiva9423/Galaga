using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform t;
    public GameObject player;
    float speed = 1f;
    bool chosen = false;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ChooseToMove());
    }


    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            //Debug.Log("is not chosen:" + (t != null && !chosen));
            if (t != null && !chosen)
            {
                transform.position = Vector3.Lerp(this.transform.position, t.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(this.transform.position, player.transform.position, speed / 2 * Time.deltaTime);
            }
        }
        

    }

    public void SetTransform(Transform whereToMove) {
        t = whereToMove;
    }


    IEnumerator ChooseToMove() {
        int r = Random.Range(0,4);
        
        yield return new WaitForSecondsRealtime(3);
        if (r == 3)
        {
            chosen = true;
        }
       
    }

    /*Move phase.This is where the enemy animation runs.*/


    /*Set position in list of enemies*/

    /*Start attack phase*/

    /*Start Moving again phase then back to attack phase.*/



}
