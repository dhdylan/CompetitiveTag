using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLagCompensationView : MonoBehaviourPun, IPunObservable
{
    private Rigidbody2D rigidBody2D;
    private Vector2 networkedPosition;
    private Vector2 networkedVelocity;
    [SerializeField]
    private float interpolateRate;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(rigidBody2D.position);
            stream.SendNext(rigidBody2D.velocity);
        }
        else
        {
            networkedPosition = (Vector2)stream.ReceiveNext();
            networkedVelocity = (Vector2)stream.ReceiveNext();

            float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
            networkedPosition += networkedVelocity * lag;
        }
    }

    void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            rigidBody2D.position = Vector2.Lerp(rigidBody2D.position, networkedPosition, Time.fixedDeltaTime * interpolateRate);
            rigidBody2D.velocity = networkedVelocity;
        }
    }
}