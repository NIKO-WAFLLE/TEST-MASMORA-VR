using UnityEngine;

public class DestroyEnemyOnHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ENEMY"))
        {
            // Avisar al EnemyManager SOLO si no es null
            if (EnemyManager.Instance != null)
            {
                EnemyManager.Instance.OnEnemyKilled();
            }

            // Destruir el enemigo
            Destroy(other.gameObject);
        }
    }
}
