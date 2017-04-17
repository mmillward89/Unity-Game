using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject {

    private int enemyHealth;

    public Enemy()
    {
        speed = 10f;
        enemyHealth = 2;
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Movement(DirectionType direction)
    {
        //Use Movingobject method
        this.Movement(GetComponent<Rigidbody2D>(), direction);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Shot":
                enemyHealth--;
                if (enemyHealth == 0)
                {
                    Destroy(this.gameObject);
                    return;
                }
                break;
        }
    }
}
