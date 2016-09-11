using UnityEngine;
using System.Collections;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;


public class Player : MonoBehaviour {

    private float speed;
    private Rigidbody2D playerRigidBody;
    Vector2 movement;

    public GameObject shot;
    public Transform shotSpawn;
    private float nextFire;
    private float fireRate;


    // Use this for initialization
    void Start () {
        speed = 10;
        fireRate = 0.25f;
        playerRigidBody = GetComponent<Rigidbody2D>();

    }
	
	void Update () {
        //Shooting
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        //Basic movement
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        movement.Set(h, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidBody.MovePosition(new Vector2(transform.position.x, transform.position.y) + movement);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }
}
