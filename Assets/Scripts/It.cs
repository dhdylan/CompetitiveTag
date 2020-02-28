using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class It : MonoBehaviour
{
    private Player thisPlayer;
    private CharacterController2D characterController2D;

    void Update()
    {
        this.thisPlayer.addItTime(Time.deltaTime);
    }

    void Awake()
    {
        thisPlayer = GetComponent<Player>();
        characterController2D = GetComponent<CharacterController2D>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Player>() != null && other.gameObject.GetComponent<It>() == null) //If the player collides with a collider that is a "Player" AND is "It"
        {
            thisPlayer.unmakeIt();
            other.gameObject.GetComponent<Player>().makeIt();
        }
    }
}
