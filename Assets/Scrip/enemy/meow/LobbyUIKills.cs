using UnityEngine;
using TMPro;

public class LobbyUIKills : MonoBehaviour
{
    public TextMeshProUGUI killsText;

    private void Start()
    {
        // Leer lo que se guardó en GameStats
        int kills = GameStats.totalKills;
        killsText.text = $"Enemigos eliminados: {kills}";
    }
}
