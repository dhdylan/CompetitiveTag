using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class KnockBackOnTrigger : MonoBehaviourPun, IPunInstantiateMagicCallback
{
    public float knockBackForce = 100f;
    public float lifetime;
    private Player owner;

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
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 9  && collider.GetComponent<PhotonView>().Owner != owner)
        {
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.transform.localScale.x * knockBackForce, 0),ForceMode2D.Impulse);
        }
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        object[] instantiationData = info.photonView.InstantiationData;
        Debug.Log(instantiationData[0]);
        owner = info.Sender;
        this.transform.localScale = (Vector2)instantiationData[0];
    }
}
