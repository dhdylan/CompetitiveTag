using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Photon.Pun;
using Photon.Realtime;

public abstract class ActiveAbility : MonoBehaviourPun
{
    public abstract void Activate();
}
