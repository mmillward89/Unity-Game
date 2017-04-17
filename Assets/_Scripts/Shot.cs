using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public float speed;
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

    public void Movement(int direction)
    {
        //Set movement
        switch (direction)
        {
            case 1:
                GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                break;
            case 2:
                GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
                break;
            case 3:
                GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
                break;
            case 4:
                GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
