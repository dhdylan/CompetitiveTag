using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Pun;
using Photon.Realtime;

public class AttachToAbiltiesObject : MonoBehaviourPun
{
    public static event Action OnAbilityAttachedToAbilitiesObject = delegate { };

    void Start()
    {
        if (photonView.IsMine)
        {
            this.transform.SetParent(PlayerManager.LocalPlayerInstance.transform.Find("Abilities"));
            OnAbilityAttachedToAbilitiesObject();
        }
    }
}
