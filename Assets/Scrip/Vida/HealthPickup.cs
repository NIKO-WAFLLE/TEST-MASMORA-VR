using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healAmount = 30f;          // Cantidad que curará el botiquín
    public bool destroyOnUse = true;        // Si quieres que desaparezca

    private void OnTriggerEnter(Collider other)
    {
        // Buscar si lo que entró es el jugador
        VRPlayerHealth playerHealth = other.GetComponent<VRPlayerHealth>();

        if (playerHealth != null)
        {
            // Curar al jugador
            playerHealth.Heal(healAmount);

            // Destruir botiquín si se usa
            if (destroyOnUse)
                Destroy(gameObject);
        }
    }
}
