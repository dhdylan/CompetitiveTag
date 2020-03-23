using UnityEngine;
using UnityEngine.EventSystems;

using Photon.Pun;

using System.Collections;

/// <summary>
/// Player manager.
/// </summary>
public class PlayerManager : MonoBehaviourPunCallbacks/*, IPunObservable*/
{
    #region Public Fields

    [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
    public static GameObject LocalPlayerInstance;

    #endregion


    #region MonoBehaviour CallBacks

    void Awake()
    {
        // #Important
        // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
        if (photonView.IsMine || !PhotonNetwork.IsConnectedAndReady)
        {
            PlayerManager.LocalPlayerInstance = this.gameObject;
            GameObject.Find("Main Camera").GetComponent<CameraFollow>().SetLocalPlayer(this.gameObject);
        }
    }

    #endregion
}