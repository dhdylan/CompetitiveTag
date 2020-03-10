using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;

public class PlayersInRoomUI : MonoBehaviour
{
    #region Private Serialized Fields

    [SerializeField]
    private List<GameObject> playerListings = new List<GameObject>();
    [SerializeField]
    private GameObject playerListingPrefab;
    [SerializeField]
    private RectTransform verticalLayoutGroupTransform;

    #endregion


    #region Public Functions

    public void UpdateUI(List<Player> playersInRoom)
    {
        clearPlayerListings();

        populatePlayerListings(playersInRoom);
    }

    #endregion


    #region Private Functions

    private void clearPlayerListings()
    {
        foreach (GameObject listing in playerListings)
        {
            Destroy(listing);
        }
        playerListings.Clear();
    }

    private void populatePlayerListings(List<Player> playersInRoom)
    {
        foreach (Player player in playersInRoom)
        {
            GameObject playerListing = Instantiate(playerListingPrefab, verticalLayoutGroupTransform);
            playerListings.Add(playerListing);
            playerListing.transform.Find("Info Container").Find("Username").GetComponent<Text>().text = player.NickName;
            playerListing.transform.Find("Info Container").Find("Is Master Client").GetComponent<Text>().text = player.IsMasterClient.ToString();
            playerListing.transform.Find("Info Container").Find("Is Local").GetComponent<Text>().text = player.IsLocal.ToString();
            playerListing.transform.Find("Info Container").Find("Actor ID").GetComponent<Text>().text = player.ActorNumber.ToString();
        }
    }

    #endregion
}
