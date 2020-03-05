using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    private Rigidbody2D rigidBody2D;
    [SerializeField]
    private float jumpForce;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 directionalInput)
    {
        rigidBody2D.AddForce(directionalInput, ForceMode2D.Impulse);
    }

    public void Jump()
    {
        this.rigidBody2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Force);
    }
}
