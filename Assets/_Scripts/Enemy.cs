using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject {

    private int enemyHealth;

	public Sprite SeenPlayerSprite;
	public Sprite StandardSprite;
	private SpriteRenderer spriteRenderer;

	public GameObject playerGameObj;
	private Player playerObj;
	private bool playerSeen;

	// Use this for initialization
	void Start () {
		playerObj = playerGameObj.GetComponent<Player>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

		speed = 10f;
		enemyHealth = 2;
		playerSeen = false;
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

	public bool checkPlayerVisibility()
	{
		bool withinDistance = false;
		bool withinSight = false;

		//Visibility check is also done in game manager but doubling up can't hurt.
		if (playerObj.Visible)
		{
			withinDistance = Vector3.Distance(playerObj.transform.position, transform.position) < 15f;
			if (withinDistance)
			{
				//If they're close enough are they in the vision cone
				Vector3 targetDir = playerObj.transform.position - transform.position;
				withinSight = Vector3.Angle(targetDir, -transform.right) <= 75.0f;
				if (!playerSeen && withinSight)
				{
					//If they are and they weren't already seen
					spriteRenderer.sprite = SeenPlayerSprite;
					playerSeen = true;
				};
			};
			
			if (playerSeen && (!withinDistance || !withinSight))
			{
				//Player has moved out of vision
				playerSeen = false;
				spriteRenderer.sprite = StandardSprite;
			}
		}
		else
		{
			//Player is never seen when invisible, regardless of position
			playerSeen = false;
			spriteRenderer.sprite = StandardSprite;
		}
		return playerSeen;
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
