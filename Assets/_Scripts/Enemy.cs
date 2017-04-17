using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject {


    public Enemy()
    {
        speed = 30f;
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
            case "Enemy":
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                break;
        }
    }
}
