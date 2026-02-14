using UnityEngine;
using UnityEngine.SceneManagement;

public class VRPlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public string Esena;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (currentHealth <= 0) return;

        currentHealth -= amount;
        Debug.Log($"Jugador recibió daño: {amount}. Vida actual: {currentHealth}");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Jugador muerto");
            // Aquí puedes:
            // - Desactivar movimiento
            SceneManager.LoadScene(Esena);
            // - Reiniciar escena, etc.
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        Debug.Log($"Jugador curado: {amount}. Vida actual: {currentHealth}");
    }


    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
