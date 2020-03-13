using System;
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

    #endregion


    #region Private Fields

    private List<PlayerListingData> playerListingDatas = new List<PlayerListingData>();

    #endregion


    #region MonoBehaviour Callbacks

    void Start()
    {
        roomNameText.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
        if(PhotonNetwork.CurrentRoom.PlayerCount == 1) {
            Debug.Log("'addPlayerListingData' is being called from Start");
            photonView.RPC("addPlayerListingData", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer);
        }
    }

    #endregion


    #region Pun Callbacks

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("'addPlayerListingData' is being called from OnPlayerEnteredRoom");
            photonView.RPC("addPlayerListingData", RpcTarget.AllBuffered, newPlayer);
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("'removePlayerListingData' is being called from OnPlayerLeftRoom");
            photonView.RPC("removePlayerListingData", RpcTarget.AllBuffered, otherPlayer);
        }
    }

    /// <summary>
    /// Called when the local player left the room. We need to load the launcher scene.
    /// </summary>
    public override void OnLeftRoom()
    {
        Debug.Log("'removePlayerListingData' is being called from OnLeftRoom");
        photonView.RPC("removePlayerListingData", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer);
        SceneManager.LoadScene(0); // Scene index 0 is the launcher scene
    }

    #endregion


    #region Public Functions

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void loadMatch()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("TestLevel");
        }
    }

    public void OnReadyButtonClicked()
    {
        photonView.RPC("togglePlayerListingDataReady", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer);
    }

    #endregion


    #region Private Functions

    [PunRPC]
    private void addPlayerListingData(Player newPlayer)
    {
        playerListingDatas.Add(new PlayerListingData(newPlayer, playerListingDatas.Count));
        playersInRoomUI.UpdateUI(playerListingDatas);
        debug_PrintPlayerListingsDatas();
    }

    [PunRPC]
    private void removePlayerListingData(Player playerToDelete)
    {
        playerListingDatas.Remove(getPlayerListingDataByPlayer(playerToDelete));
        playersInRoomUI.UpdateUI(playerListingDatas);
        debug_PrintPlayerListingsDatas();
    }

    [PunRPC]
    private void togglePlayerListingDataReady(Player playertoReady)
    {
        PlayerListingData playerListingData = getPlayerListingDataByPlayer(playertoReady);
        if (playerListingData.ready)
        {
            playerListingData.ready = false;
        }
        else
        {
            playerListingData.ready = true;
        }

        playersInRoomUI.UpdateUI(playerListingDatas);

        debug_PrintPlayerListingsDatas();
        Debug.Log("============ All Players Ready : " + allPlayersReady() + "==================");

        if (allPlayersReady())
        {
            Debug.Log("All players ready. Starting match.");
            loadMatch();
        }

    }

    private bool allPlayersReady()
    {
        foreach (PlayerListingData playerListingData in playerListingDatas)
        {
            if (!playerListingData.ready)
            {
                return false;
            }
        }
        return true;
    }

    #endregion


    #region Utility

    private PlayerListingData getPlayerListingDataByPlayer(Player player)
    {
        return playerListingDatas.Find(playerListingData => playerListingData.player == player);

    }

    private void debug_PrintPlayerListingsDatas()
    {
        Debug.Log("=====================Player Listing Datas=================");
        foreach (PlayerListingData playerListingData in playerListingDatas)
        {
            Debug.Log("Username: " + playerListingData.player.NickName);
            Debug.Log("Ready: " + playerListingData.ready);
            Debug.Log("UISlot: " + playerListingData.UISlot);
            Debug.Log("===");
        }
    }

    #endregion
}

public class PlayerListingData
{
    public Player player;
    public bool ready = false;
    public int UISlot;

    public PlayerListingData(Player player, int UISlot)
    {
        this.player = player;
        this.UISlot = UISlot;
    }
}