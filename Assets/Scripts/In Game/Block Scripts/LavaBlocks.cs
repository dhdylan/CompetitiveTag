using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBlocks : MonoBehaviour
{
    public float upwardForce = 100f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9) // everything inside this statement will happen to the player when it touches lava.
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);
        }
    }
}
