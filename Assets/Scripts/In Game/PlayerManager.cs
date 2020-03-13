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

    #region Serialized Private Fields

    [SerializeField]
    private double _totalItTime = 0;

    [SerializeField]
    private GameObject mainCameraPrefab;

    #endregion

    //#region IpunObservable implementation
    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        // We own this player: send the others our data
    //    }
    //    else
    //    {
    //        // Network player, receive data
    //    }
    //}

    //#endregion

    #region MonoBehaviour CallBacks

    void Start()
    {
        mainCameraPrefab = Instantiate(mainCameraPrefab);

    }

    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
    /// </summary>
    void Awake()
    {
        // #Important
        // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
        if (photonView.IsMine)
        {
            PlayerManager.LocalPlayerInstance = this.gameObject;
            //mainCameraPrefab.GetComponent<SmoothFollow>().target = this.gameObject.transform;

        }
    }
    #endregion

    #region Public Methods

    public double totalItTime
    {
        get
        {
            return _totalItTime;
        }
    }

    public void addItTime(double itTime)
    {
        _totalItTime += itTime;
    }
    public void makeIt()
    {
        this.gameObject.AddComponent<It>();
    }
    public void unmakeIt()
    {
        Destroy(GetComponent<It>());
    }

    #endregion
}