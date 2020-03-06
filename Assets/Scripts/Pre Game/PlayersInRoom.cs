using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayersInRoom : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("=================== Players In Room =================================================");
        foreach (Player player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            Debug.LogFormat("Username: {0}   ||   Is Master: {1}   ||   Is Local: {2}   ||   Actor Name: {3}", player.NickName, player.IsMasterClient, player.IsLocal, player.ActorNumber);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("=================== Players In Room =================================================");
        foreach (Player player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            Debug.LogFormat("Username: {0}   ||   Is Master: {1}   ||   Is Local: {2}   ||   Actor Name: {3}", player.NickName, player.IsMasterClient, player.IsLocal, player.ActorNumber);
        }
    }
    public override void OnPlayerLeftRoom(Player leavingPlayer)
    {
        Debug.Log("=================== Players In Room =================================================");
        foreach (Player player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            Debug.LogFormat("Username: {0}   ||   Is Master: {1}   ||   Is Local: {2}   ||   Actor Name: {3}", player.NickName, player.IsMasterClient, player.IsLocal, player.ActorNumber);
        }
    }
}
