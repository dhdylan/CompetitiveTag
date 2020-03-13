using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using Photon.Pun;

public class PlayerUsername : MonoBehaviourPun
{
    [SerializeField]
    private GameObject usernameGameObject;
    private TextMeshPro usernameTMPro;

    void Start()
    {
        usernameTMPro = usernameGameObject.GetComponent<TextMeshPro>();
        usernameTMPro.SetText(PhotonNetwork.LocalPlayer.NickName);
    }
}
