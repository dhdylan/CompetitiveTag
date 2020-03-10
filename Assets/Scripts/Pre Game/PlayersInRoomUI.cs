using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;

public class PlayersInRoomUI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> playerListings = new List<GameObject>();
    [SerializeField]
    private GameObject playerListingPrefab;
    [SerializeField]
    private RectTransform verticalLayoutGroupTransform;


    public void UpdateUI(Dictionary<int, Player> playersInRoom)
    {
        clearPlayerListings();

        populatePlayerListings(playersInRoom);
    }

    private void clearPlayerListings()
    {
        foreach (GameObject listing in playerListings)
        {
            PhotonNetwork.Destroy(listing);
        }
        playerListings.Clear();
    }

    private void populatePlayerListings(Dictionary<int, Player> playersInRoom)
    {
        foreach (Player player in playersInRoom.Values)
        {
            GameObject playerListing = Instantiate(playerListingPrefab, verticalLayoutGroupTransform);
            playerListings.Add(playerListing);
            playerListing.transform.Find("Username").GetComponent<Text>().text = player.NickName;
            playerListing.transform.Find("Is Master Client").GetComponent<Text>().text = player.IsMasterClient.ToString();
            playerListing.transform.Find("Is Local").GetComponent<Text>().text = player.IsLocal.ToString();
            playerListing.transform.Find("Actor ID").GetComponent<Text>().text = player.ActorNumber.ToString();
        }
    }


}
