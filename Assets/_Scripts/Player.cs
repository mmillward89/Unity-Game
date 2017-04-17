﻿using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float speed;
    private Rigidbody2D playerRigidBody;
    Vector2 Movement;

    public GameObject Shot;
    public Transform shotSpawn;
    private int playerHealth;
    private float nextFireTime;
    private float fireRate;

    // Use this for initialization
    void Start()
    {
        playerHealth = 50;
        speed = 10;
        fireRate = 0.1f;
        nextFireTime = .5f;
        playerRigidBody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        //shooting
        if (Input.GetKeyDown(KeyCode.W) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            shotSpawn.position = transform.position + new Vector3(0, 1.5f, 0);
            (Instantiate(Shot, shotSpawn.position, shotSpawn.rotation) as GameObject).GetComponent<Shot>().Movement(DirectionType.Up);
        }
        if (Input.GetKeyDown(KeyCode.S) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            shotSpawn.position = transform.position + new Vector3(0, -1.5f, 0);
            (Instantiate(Shot, shotSpawn.position, shotSpawn.rotation) as GameObject).GetComponent<Shot>().Movement(DirectionType.Down);
        }
        if (Input.GetKeyDown(KeyCode.A) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            shotSpawn.position = transform.position + new Vector3(-1.5f, 0, 0);
            (Instantiate(Shot, shotSpawn.position, shotSpawn.rotation) as GameObject).GetComponent<Shot>().Movement(DirectionType.Left);
        }
        if (Input.GetKeyDown(KeyCode.D) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            shotSpawn.position = transform.position + new Vector3(1.5f, 0, 0);
            (Instantiate(Shot, shotSpawn.position, shotSpawn.rotation) as GameObject).GetComponent<Shot>().Movement(DirectionType.Right);
        }
    }

    void FixedUpdate()
    {
        //Basic Movement
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Movement.Set(h, v);
        Movement = Movement.normalized * speed * Time.deltaTime;
        playerRigidBody.MovePosition(new Vector2(transform.position.x, transform.position.y) + Movement);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;

        switch (collision.gameObject.tag)
        {
            case "Enemy":
                Destroy(collision.gameObject);
                DamagePlayer();
                break;
        }
    }

    private void DamagePlayer()
    {
        if(playerHealth == 10)
        {
            Destroy(this.gameObject);
            return;
        }

        playerHealth = playerHealth - 10;
    }

}
