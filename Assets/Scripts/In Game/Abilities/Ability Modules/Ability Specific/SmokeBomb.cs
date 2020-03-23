using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SmokeBomb : MonoBehaviourPun
{
    private Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            rigidBody2D.isKinematic = true;
            rigidBody2D.constraints = RigidbodyConstraints2D.FreezeAll;

            photonView.RPC("ModifyComponents", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    public void ModifyComponents()
    {
        Destroy(this.GetComponent<PhotonLagCompensationView>());
        this.gameObject.AddComponent<DestroyAfterSeconds>();
        this.GetComponent<DestroyAfterSeconds>().lifetime = 4f;
    }
}
