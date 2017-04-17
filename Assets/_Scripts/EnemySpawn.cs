﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawn : MonoBehaviour {

    public GameObject Enemy;
    private float enemyRate, nextEnemyTime;
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
            (Instantiate(Enemy, transform.position, transform.rotation) as GameObject).GetComponent<Enemy>().Movement(DirectionType.Left);
        }
	}
}