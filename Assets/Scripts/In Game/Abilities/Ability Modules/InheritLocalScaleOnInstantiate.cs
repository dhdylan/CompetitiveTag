using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InheritLocalScaleOnInstantiate : MonoBehaviourPun, IPunInstantiateMagicCallback
{
    // using this class requires that a Vector2 containing the local X and Y scale be sent as InstantiationData when instantiated.
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        object[] instantiationData = info.photonView.InstantiationData;
        this.transform.localScale = (Vector2)instantiationData[0];
    }
}
