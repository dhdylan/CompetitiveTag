using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLagCompensationView : MonoBehaviourPun, IPunObservable
{
    private Rigidbody2D rigidBody;
    private Vector2 networkedPosition;
    private Vector2 networkedVelocity;
    [SerializeField]
    private float interpolateRate;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(rigidBody.position);
            stream.SendNext(rigidBody.velocity);
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
            rigidBody.position = Vector2.Lerp(rigidBody.position, networkedPosition, Time.fixedDeltaTime * interpolateRate);
            rigidBody.velocity = networkedVelocity;
        }
    }
}