using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField RoomNameInput;
    [SerializeField] private TMP_InputField MaxPlayersInput;
    [SerializeField] private GameObject RoomPanel;
    [SerializeField] private GameObject CreateRoomPanel;

    public void CreateRoom()
    {
        string roomName = RoomNameInput.text;
        byte maxPlayers = byte.Parse(MaxPlayersInput.text);
        RoomOptions roomOptions = new RoomOptions { MaxPlayers = maxPlayers };
        PhotonNetwork.CreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Creating a room has failed: " + message);
    }

    public override void OnJoinedRoom()
    {
        RoomPanel.SetActive(false);
        CreateRoomPanel.SetActive(true);
        FindObjectOfType<RoomUIManager>().UpdatePlayerList();
    }

    public override void OnCreatedRoom()
    {
        RoomPanel.SetActive(false);
        CreateRoomPanel.SetActive(true);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Joining a room has failed: " + message);
    }
}
