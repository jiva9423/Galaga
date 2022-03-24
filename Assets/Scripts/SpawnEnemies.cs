using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject spawn1; //spawn point for enemies on right of world
    public GameObject spawn2; //spawn point for enemies on left of world
    float speed = 1f; // speed of plane
    public float fireRate = 0.5F; // fire rate of enemy
    private float nextFire = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnEnemy();
        int count = transform.childCount;
        //spawn enemies on the grid
        for (int i = 0; i < count; i++) {
            MoveEnemyToGrid();
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy(); // spawn enemy planes
        MoveSideToSide(); // have planes move side to side
    }

    // spawn enemy planes
    void SpawnEnemy() {

        if (Time.time > nextFire)
        {
            fireRate = Random.Range(1f, 4f);
            nextFire = Time.time + fireRate;
            MoveEnemyToGrid();
        }
        
    }

    // enemy planes move side to side
    void MoveSideToSide() {
        Vector3 pos1 = new Vector3(-5, 0, 0);
        Vector3 pos2 = new Vector3(5, 0, 0);
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);

    }


    // put spawned enemy planes on a grid
    void MoveEnemyToGrid() {
        int children = transform.childCount;
        
        //check if any spots are open to add a new enemy plane;
        for (int i = 0; i < children; i++) {
            Transform t = transform.GetChild(i);
            GameObject gameObject = t.gameObject;
            EnemyCheck c = gameObject.GetComponent<EnemyCheck>();

            // spot is open so add a new enemy plane to the grid
            if (!c.getFilled()) {
                MoveEnemyHere(t);
                c.setFilled(true);
                return;
            }
        }

    }

    // move enemy to an open spot in the grid
    void MoveEnemyHere(Transform t) {
        GameObject enemy;
        int r = Random.Range(0,2);
        if (r == 0) {
            enemy = Instantiate(Enemy1, spawn1.transform.position, spawn1.transform.rotation, t);
        }
        else{
            enemy = Instantiate(Enemy1, spawn2.transform.position, spawn2.transform.rotation, t);
        }
        //enemy.transform.position = new Vector3(20, 0, 20);
        EnemyMovement en = enemy.GetComponent<EnemyMovement>();
        en.SetTransform(t);
    }
}
