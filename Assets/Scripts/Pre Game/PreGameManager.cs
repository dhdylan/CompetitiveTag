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

        addPlayerListingData(PhotonNetwork.LocalPlayer); // this should be adding the first (and currently the only) player in the room as the master
    }

    #endregion


    #region Pun Callbacks

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        addPlayerListingData(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        removePlayerListingData(otherPlayer);
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

    public void loadMatch()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("TestLevel");
        }
    }

    public void OnReadyButtonClicked()
    {
        togglePlayerListingDataReady(playerListingDatas.Find(playerListingData => playerListingData.player == PhotonNetwork.LocalPlayer));
    }

    #endregion


    #region Private Functions

    private void addPlayerListingData(Player newPlayer)
    {
        playerListingDatas.Add(new PlayerListingData(newPlayer, playerListingDatas.Count));
        debug_PrintPlayerListingsDatas();
    }

    private void removePlayerListingData(Player playerToDelete)
    {
        playerListingDatas.RemoveAt(playerListingDatas.FindIndex(playerListingData => playerListingData.player == playerToDelete));
        debug_PrintPlayerListingsDatas();
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

    private void togglePlayerListingDataReady(PlayerListingData playerListingData)
    {
        if(playerListingData.ready){
            playerListingData.ready = false;
        }
        else
        {
            playerListingData.ready = true;
        }

        Debug.Log("============ All Players Ready : " + allPlayersReady() + "==================");
    }


    private void debug_PrintPlayerListingsDatas()
    {
        Debug.Log("=====================Player Listing Datas=================");
        foreach(PlayerListingData playerListingData in playerListingDatas)
        {
            Debug.Log("Username: " + playerListingData.player.NickName);
            Debug.Log("Ready: " + playerListingData.ready);
            Debug.Log("UISlot: " + playerListingData.UISlot);
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