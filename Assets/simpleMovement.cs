using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMovement : MonoBehaviour
{
    public Vector2 moveDirection;
    public float jumpHeight = 100;
    public float jumpMulti = 1.5f;
    public float moveSpeed = 10;
    public float fallMulti = 2.5f;
    //public float smallFallMulti = 2;
    public float dashDistance;
    public int dashFrames = 8;



    private Rigidbody2D playerRigidbody;
    private float gravity;
    private RaycastHit groundcheckHit;
    private Animator playerAnimator;
    private bool grounded;
    private bool crouched;
    private bool dashing;
    private int dashTimer = 0;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0f);
        playerRigidbody.AddForce(moveDirection * Time.deltaTime * moveSpeed, ForceMode2D.Impulse);
    }
}
