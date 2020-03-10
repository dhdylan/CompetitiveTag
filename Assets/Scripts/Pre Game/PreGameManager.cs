using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreGameManager : MonoBehaviourPunCallbacks
{
    #region Private Serialized Fields
    
    [SerializeField]
    private PlayersInRoomUI playersInRoomUI;
    [SerializeField]
    private Text roomNameText;
    [SerializeField]
    private int numberOfReadyPlayers = 0;

    #endregion


    #region Private Fields

    private List<Player> playersInRoom = new List<Player>();

    #endregion


    #region MonoBehaviour Callbacks

    void Start()
    {
        getPlayersInRoom();
        playersInRoomUI.UpdateUI(playersInRoom);
        roomNameText.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
    }

    #endregion


    #region Pun Callbacks

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        playersInRoomUI.UpdateUI(playersInRoom);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        playersInRoomUI.UpdateUI(playersInRoom);
    }

    /// <summary>
    /// Called when the local player left the room. We need to load the launcher scene.
    /// </summary>
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0); // Scene index 0 is the launcher scene
    }

    #endregion


    #region Public Functions

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void AddReadyPlayer()
    {
        Debug.Log("addedReadyPlayer");
        numberOfReadyPlayers = numberOfReadyPlayers + 1;
        checkIfAllPlayersReady();
    }

    public void SubtractReadyPlayer()
    {
        numberOfReadyPlayers = numberOfReadyPlayers - 1;
        checkIfAllPlayersReady();
        Debug.Log("addedReadyPlayer");

    }

    #endregion


    #region Private Functions

    private void getPlayersInRoom()
    {
        playersInRoom.Clear();
        foreach(Player player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            playersInRoom.Add(player);
        }
    }

    private void checkIfAllPlayersReady()
    {
        if(numberOfReadyPlayers == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            Debug.Log("countdown begin");
        }
        else
        {
            Debug.Log("Waiting on more players to ready");
        }
    }

    #endregion
}
