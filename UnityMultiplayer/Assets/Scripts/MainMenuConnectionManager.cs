using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class MainMenuConnectionManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI StatusText;
    [SerializeField] private TMP_InputField LobbyNameInput;
    [SerializeField] private TMP_InputField LobbyIDInput;
    [SerializeField] private GameObject LobbyPanel;
    [SerializeField] private GameObject CreateRoomPanel;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        StatusText.text = "Connecting to server...";
    }

    public override void OnConnectedToMaster()
    {
        StatusText.text = "Successfully connected to server.";
    }

    public void JoinSpecificLobby()
    {
        string lobbyName = LobbyNameInput.text;
        string lobbyID = LobbyIDInput.text;

        if (!string.IsNullOrEmpty(lobbyName))
        {
            TypedLobby customLobby = new TypedLobby(lobbyName, LobbyType.Default);
            PhotonNetwork.JoinLobby(customLobby);
            StatusText.text = $"Joining lobby: {lobbyName}...";
        }
        else if (!string.IsNullOrEmpty(lobbyID))
        {
            TypedLobby customLobby = new TypedLobby(lobbyID, LobbyType.Default);
            PhotonNetwork.JoinLobby(customLobby);
            StatusText.text = $"Joining lobby with ID: {lobbyID}...";
        }
        else
        {
            PhotonNetwork.JoinLobby(TypedLobby.Default);
            StatusText.text = "Joining default lobby...";
        }
    }

    public override void OnJoinedLobby()
    {
        StatusText.text = "Successfully joined a lobby.";
        LobbyPanel.SetActive(false);
        CreateRoomPanel.SetActive(true);
    }
}
