using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EnemySpawn : MonoBehaviour {

    public GameObject Enemy;
    private float enemyRate, nextEnemyTime;
    private System.Random rng;

    public EnemySpawn()
    {
        rng = new System.Random();
    }

	// Use this for initialization
	void Start () {
        enemyRate = 1.0f;
        nextEnemyTime = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextEnemyTime)
        {
            nextEnemyTime = Time.time + enemyRate;
            switch(rng.Next(4))
            {
                case 0:
                    (Instantiate(Enemy, transform.position + new Vector3((float)rng.Next(-16, 13), -17, 0), transform.rotation) as GameObject).GetComponent<Enemy>().Movement(DirectionType.Up);
                    break;
                case 1:
                    (Instantiate(Enemy, transform.position + new Vector3((float)rng.Next(-16, 13), 17, 0), transform.rotation) as GameObject).GetComponent<Enemy>().Movement(DirectionType.Down);
                    break;
                case 2:
                    (Instantiate(Enemy, transform.position + new Vector3(16, (float)rng.Next(-14, 15), 0), transform.rotation) as GameObject).GetComponent<Enemy>().Movement(DirectionType.Left);
                    break;
                case 3:
                    (Instantiate(Enemy, transform.position + new Vector3(-19, (float)rng.Next(-14, 15), 0), transform.rotation) as GameObject).GetComponent<Enemy>().Movement(DirectionType.Right);
                    break;
                default:
                    break;
            }
            
        }
	}
    
}
