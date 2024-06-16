using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject RoomListContent;
    [SerializeField] private GameObject RoomListItemPrefab;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform child in RoomListContent.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (RoomInfo room in roomList)
        {
            GameObject availableRoomItem = Instantiate(RoomListItemPrefab, RoomListContent.transform);
            availableRoomItem.GetComponent<RoomItemList>().SetUp(room);
            availableRoomItem.GetComponent<Button>().onClick.AddListener(() => JoinRoom(room.Name));
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }
}
