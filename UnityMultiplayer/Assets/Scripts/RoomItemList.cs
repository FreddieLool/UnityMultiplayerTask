using Photon.Realtime;
using UnityEngine;
using TMPro;
public class RoomItemList : MonoBehaviour
{
    public TextMeshProUGUI RoomNameText;

    public void SetUp(RoomInfo roomInfo)
    {
        RoomNameText.text = $"{roomInfo.Name} ({roomInfo.PlayerCount}/{roomInfo.MaxPlayers})";
    }

}
