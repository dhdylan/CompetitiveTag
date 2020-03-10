using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PreGameManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private PlayersInRoomUI playersInRoomUI;

    void Start()
    {
        playersInRoomUI.UpdateUI(PhotonNetwork.CurrentRoom.Players);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        playersInRoomUI.UpdateUI(PhotonNetwork.CurrentRoom.Players);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        playersInRoomUI.UpdateUI(PhotonNetwork.CurrentRoom.Players);
    }
}
