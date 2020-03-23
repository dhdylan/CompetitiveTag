using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class KnockBackOnTrigger : MonoBehaviourPun
{
    public bool knockAway = true;
    public ForceMode2D forceMode;
    public float knockBackForce = 100f;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 9  && collider.GetComponent<PhotonView>().Owner != photonView.Owner)
        {
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.transform.localScale.x  * Convert.ToByte(knockAway) * knockBackForce, 0), forceMode);
        }
    }
}
