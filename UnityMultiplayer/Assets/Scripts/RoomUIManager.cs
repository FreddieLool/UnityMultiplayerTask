using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomUIManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject PlayerListContent;  
    [SerializeField] private GameObject PlayerListItemPrefab; 
    [SerializeField] private GameObject RoomPanel;
    [SerializeField] private GameObject LobbyPanel; 

    public override void OnJoinedRoom()
    {
        UpdatePlayerList();
        RoomPanel.SetActive(true);
        LobbyPanel.SetActive(false);
    }

    public void UpdatePlayerList()
    {
        if (PlayerListContent == null)
        {
            Debug.LogError("PlayerListContent is not assigned.");
            return;
        }

        if (PlayerListItemPrefab == null)
        {
            Debug.LogError("PlayerListItemPrefab is not assigned.");
            return;
        }

        foreach (Transform child in PlayerListContent.transform)
        {
            Destroy(child.gameObject);
        }

        // Create a new list item for each player
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            GameObject playerListItem = Instantiate(PlayerListItemPrefab, PlayerListContent.transform);
            PlayerItemList playerItemList = playerListItem.GetComponent<PlayerItemList>();

            if (playerItemList != null)
            {
                playerItemList.SetUp(player);
            }
            else
            {
                Debug.LogError("PlayerItemList component not found on PlayerListItemPrefab.");
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }
}