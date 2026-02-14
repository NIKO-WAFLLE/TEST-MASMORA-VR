using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [Header("Escena a la que se regresa")]
    public string lobbySceneName = "Lobby";

    [Header("Conteo de enemigos")]
    public int enemiesAlive = 0;
    public int killsThisRound = 0;

    private void Awake()
    {
        // Singleton simple
        if (Instance == null)
        {
            Instance = this;
            // Opcional: que no se destruya al cambiar de escena
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //  La idea es que CADA enemigo llame a esto en su Start/Awake
    public void RegisterEnemy()
    {
        enemiesAlive++;
        Debug.Log("[EnemyManager] Enemy registrado. Vivos: " + enemiesAlive);
    }

    public void OnEnemyKilled()
    {
        killsThisRound++;
        enemiesAlive--;

        if (enemiesAlive < 0) enemiesAlive = 0;

        GameStats.totalKills = killsThisRound;

        Debug.Log($"[EnemyManager] Enemy muerto. Vivos: {enemiesAlive}, Kills: {killsThisRound}");

        if (enemiesAlive == 0)
        {
            SceneManager.LoadScene(lobbySceneName);
        }
    }
}
