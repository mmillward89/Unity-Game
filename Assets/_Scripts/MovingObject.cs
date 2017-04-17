using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public abstract class MovingObject : MonoBehaviour
{
    protected float speed;

    public void Movement(Rigidbody2D rigidBody, DirectionType direction)
    {
        //Set movement
        switch (direction)
        {
            case DirectionType.Up:
                rigidBody.velocity = Vector2.up * speed;
                break;
            case DirectionType.Down:
                rigidBody.velocity = Vector2.down * speed;
                break;
            case DirectionType.Left:
                rigidBody.velocity = Vector2.left * speed;
                break;
            case DirectionType.Right:
                rigidBody.velocity = Vector2.right * speed;
                break;
        }
    }
}

