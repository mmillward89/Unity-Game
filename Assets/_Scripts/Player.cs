using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public bool Visible { get; set; }

	private float speed;
	private Rigidbody2D playerRigidBody;
	Vector2 Movement;

	public GameObject Shot;
	public Transform shotSpawn;
	private int playerHealth;

	// Use this for initialization
	void Start()
	{
		playerHealth = 50;
		speed = 10;
		playerRigidBody = GetComponent<Rigidbody2D>();
		Visible = true;

	}

	void Update()
	{
		checkVisibilityInput();
	}

	void FixedUpdate()
	{
		checkMovement();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		GetComponent<Rigidbody2D>().freezeRotation = true;

		switch (collision.gameObject.tag)
		{
			case "Enemy":
				break;
		}
	}

	private void checkVisibilityInput()
	{
		if (Input.GetKeyUp(KeyCode.Joystick1Button0))
		{
			Visible = !Visible;
		}
	}

	public void checkMovement()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		Movement.Set(h, v);
		Movement = Movement.normalized * speed * Time.deltaTime;
		playerRigidBody.MovePosition(new Vector2(transform.position.x, transform.position.y) + Movement);
	}

	private void DamagePlayer()
	{
		if (playerHealth == 10)
		{
			Destroy(this.gameObject);
			return;
		}

		playerHealth = playerHealth - 10;
	}

}
