using System;
using System.Collections.Generic;

using UnityEngine;
using Photon.Pun;

class DestroyAfterSeconds : MonoBehaviourPun
{
    public float lifetime = 1f;

    void Update()
    {
        if (photonView.IsMine)
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0)
            {
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
    }
}