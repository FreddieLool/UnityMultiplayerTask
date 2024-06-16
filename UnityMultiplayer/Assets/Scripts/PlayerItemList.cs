using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemList : MonoBehaviour
{
    public TextMeshProUGUI PlayerNameText;

    public void SetUp(Player player)
    {
        if (PlayerNameText != null)
        {
            PlayerNameText.text = player.NickName;
        }
        else
        {
            Debug.LogError("PlayerNameText is not assigned.");
        }
    }
}

