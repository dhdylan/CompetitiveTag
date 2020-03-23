using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InstantiatePrefabAbility : ActiveAbility
{
    [SerializeField]
    private GameObject objectToBeInstantiated;
    [SerializeField]
    private Transform instantiationPoint;

    public override void Activate()
    {
        object[] instantiationData = new object[1];
        instantiationData[0] = (Vector2)this.transform.root.localScale;
        PhotonNetwork.Instantiate(objectToBeInstantiated.name, instantiationPoint.position, Quaternion.identity, 0, instantiationData);
    }
}