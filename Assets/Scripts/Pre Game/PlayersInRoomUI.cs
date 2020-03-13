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
    [SerializeField]
    private PreGameManager preGameManager;

    #endregion


    #region Public Functions

    public void UpdateUI(List<PlayerListingData> playerListingDatas)
    {
        clearPlayerListings();
        drawPlayerListings(playerListingDatas);
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

    private void drawPlayerListings(List<PlayerListingData> playerListingDatas)
    {
        foreach (PlayerListingData playerListingData in playerListingDatas)
        {
            GameObject playerListing = Instantiate(playerListingPrefab, verticalLayoutGroupTransform);
            playerListings.Add(playerListing);
            if (playerListingData.ready)
            {
                playerListing.transform.Find("Ready").GetComponentInChildren<Image>().color = Color.green;
            }
            else
            {
                playerListing.transform.Find("Ready").GetComponentInChildren<Image>().color = Color.red;
            }
            playerListing.transform.Find("Info Container").Find("Username").GetComponent<Text>().text = playerListingData.player.NickName;


            //playerListing.transform.Find("Info Container").Find("Is Master Client").GetComponent<Text>().text = player.IsMasterClient.ToString();
            //playerListing.transform.Find("Info Container").Find("Is Local").GetComponent<Text>().text = player.IsLocal.ToString();
            //playerListing.transform.Find("Info Container").Find("Actor ID").GetComponent<Text>().text = player.ActorNumber.ToString();
        }
    }

    #endregion
}
