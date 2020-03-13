using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tagger : MonoBehaviour
{
    private PlayerManager thisPlayer;

    void Start()
    {
        thisPlayer = GetComponentInParent<PlayerManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerManager>() != null && other.gameObject.GetComponent<It>() == null) //If the player collides with a collider that is a "Player" AND isn't "It"
        {
            Debug.Log("tag youre it");
            thisPlayer.unmakeIt();
            other.gameObject.GetComponent<PlayerManager>().makeIt();
        }
    }
}
