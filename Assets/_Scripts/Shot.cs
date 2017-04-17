using UnityEngine;
using System.Collections;

public class Shot : MovingObject {

    public Shot()
    {
        speed = 30f;
    }

	// Use this for initialization
	void Start () {
            
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
		switch(collision.gameObject.tag) {
			case "Enemy":
				Destroy(collision.gameObject);
				Destroy(this.gameObject);
			break;
		}
    }

    public void Movement(DirectionType direction)
    {
        //Use Movingobject method
        this.Movement(GetComponent<Rigidbody2D>(), direction);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
