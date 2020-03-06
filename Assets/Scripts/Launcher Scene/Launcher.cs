using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class Launcher : MonoBehaviourPunCallbacks
{
    #region Private Serializable Fields

    /// <summary>
    /// The maximum number of players per room. When a room is full, it can't be joined by new players, and so a new room will be created.
    /// </summary>
    /// 
    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so a new room will be created.")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;

    [Tooltip("The Ui Panel to let the user enter name, connect and play")]
    [SerializeField]
    private GameObject controlPanel;
    [Tooltip("The UI Label to inform the user that the connection is in progress")]
    [SerializeField]
    private GameObject progressLabel;

    [SerializeField]
    private GameObject roomNameInputFieldObject;
    private InputField roomNameInputField;

    #endregion


    #region Private Fields


    /// <summary>
    /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
    /// </summary>
    string gameVersion = "1";

    /// <summary>
    /// Keep track of the current process. Since connection is asynchronous and is based on several callbacks from Photon,
    /// we need to keep track of this to properly adjust the behavior when we receive call back by Photon.
    /// Typically this is used for the OnConnectedToMaster() callback.
    /// </summary>
    bool isConnecting;


    #endregion


    #region MonoBehaviour CallBacks


    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
    /// </summary>
    void Awake()
    {
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during initialization phase.
    /// </summary>
    void Start()
    {
        controlPanel.SetActive(true);
        progressLabel.SetActive(false);
        roomNameInputField = roomNameInputFieldObject.GetComponent<InputField>();
    }


    #endregion


    #region Public Methods


    /// <summary>
    /// Start the connection process.
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// </summary>
    public void Connect()
    {
        PhotonNetwork.GameVersion = gameVersion;
        isConnecting = PhotonNetwork.ConnectUsingSettings();

        progressLabel.SetActive(true);
        controlPanel.SetActive(false);
    }


    #endregion


    #region MonoBehaviourPunCallbacks Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");

        if (isConnecting)
        {
            // #Critical: The first thing we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
            PhotonNetwork.JoinOrCreateRoom(roomNameInputField.text, new RoomOptions { MaxPlayers = maxPlayersPerRoom }, TypedLobby.Default);
            isConnecting = false;
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        controlPanel.SetActive(true);
        progressLabel.SetActive(false);
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinRandomFailed() was called by PUN. No random room avilable, se we will create one. Calling: PhotonNetwork.CreateRoom()");
            
        // #Critical: we failed to join a room; No rooms exist or they are all full. We will create a new one
        PhotonNetwork.CreateRoom("room", new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() was called by PUN. Now this client is in a room.");

        // #Critical: We only load if we are the first player, else we rely on "PhotoNetwork.AutomaticallySyncScene" to sync our instance scene.
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {

            // #Critical
            // Load the Room Level.
            PhotonNetwork.LoadLevel("Pre Game");
        }
    }

    #endregion
}