using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChangeSpriteOnCollision : MonoBehaviourPun
{
    [SerializeField]
    private Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private LayerMask collideableLayers;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collideableLayers == 1 << collision.gameObject.layer) {
            SwitchSprite();
        }
    }

    private void SwitchSprite()
    {
        spriteRenderer.sprite = newSprite; 
    }
}
