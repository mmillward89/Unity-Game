using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject {

    private int enemyHealth;
	public GameObject playerGameObj;
	private Player playerObj;

	// Use this for initialization
	void Start () {
		speed = 10f;
		enemyHealth = 2;
		playerObj = playerGameObj.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		checkPlayerVisibility();
	}

    public void Movement(DirectionType direction)
    {
        //Use Movingobject method
        this.Movement(GetComponent<Rigidbody2D>(), direction);
    }

	public void checkPlayerVisibility()
	{
		if((Vector3.Distance(playerObj.transform.position, transform.position)) < 15f)
		{
			Vector3 targetDir = playerObj.transform.position - transform.position;
			if(Vector3.Angle(targetDir, -transform.right) <= 75.0f && playerObj.visible)
			{
				var test = "";
			}
		}
	}


	void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {

        }
    }

    private void DamageEnemy()
    {
        enemyHealth--;
        if (enemyHealth == 0)
        {
            Destroy(this.gameObject);
            return;
        }
    }
}
