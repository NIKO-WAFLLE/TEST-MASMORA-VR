using UnityEngine;

public class HitBox : MonoBehaviour
{
    public float damage = 10f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VRPlayerHealth health = other.GetComponent<VRPlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
                Debug.Log("[HitBox] daño aplicado al jugador");
            }
        }
    }
}
