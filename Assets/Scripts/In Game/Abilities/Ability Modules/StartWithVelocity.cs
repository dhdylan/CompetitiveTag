using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWithVelocity : MonoBehaviour
{
    public Vector2 velocity;

    private Rigidbody2D rigidBody2D;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
    }
}
