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
                Destroy(this.gameObject);
                break;
        }
    }
}
