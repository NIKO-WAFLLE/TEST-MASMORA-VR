using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyHealth : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 3;
    private int currentHealth;
    public int damagePerHit = 1;         // Cuánto le baja cada golpe de la espada
    public string weaponTag = "SWORD";   // Tag del arma

    [Header("Referencia opcional")]
    public Zombie1 zombieAI;             // Arrastra aquí tu script Zombie1 (o lo tomamos en Start)
    public Animator animator;            // Si lo quieres para animación de muerte

    [Header("Drop al morir")]
    [Tooltip("Prefabs entre los que se elegirá uno cuando muera")]
    public GameObject[] dropPrefabs;     // Igual que tu Prefab Spawner
    public Transform dropPoint;          // Lugar donde aparecerá el objeto (si es null usa la posición del enemigo)

    public float destroyDelay = 3f;      // Tiempo para destruir el enemigo después de morir

    private bool isDead = false;
    private bool lootDropped = false;

    void Start()
    {
        currentHealth = maxHealth;

        if (zombieAI == null)
            zombieAI = GetComponent<Zombie1>();

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    // Llamado cuando el enemigo recibe daño
    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        // Apagar IA de movimiento/ataque
        if (zombieAI != null)
            zombieAI.enabled = false;

        // Animación de muerte (ajusta el nombre del parámetro según tu Animator)
        if (animator != null)
        {
            animator.SetBool("run", false);
            animator.SetBool("walk", false);
            animator.SetBool("attack", false);
            animator.SetTrigger("die");  // Usa "die" si tienes ese trigger
        }

        // Drop de un solo objeto
        DropLootOnce();

        // Destruir el enemigo después de un tiempo
        Destroy(gameObject, destroyDelay);
    }

    private void DropLootOnce()
    {
        if (lootDropped) return;
        lootDropped = true;

        if (dropPrefabs == null || dropPrefabs.Length == 0)
            return;

        // Filtrar prefabs que no son null
        List<GameObject> validPrefabs = new List<GameObject>();
        foreach (var p in dropPrefabs)
        {
            if (p != null)
                validPrefabs.Add(p);
        }

        if (validPrefabs.Count == 0)
            return;

        // Elegimos UNO al azar (solo uno)
        GameObject prefabToSpawn = validPrefabs[Random.Range(0, validPrefabs.Count)];

        Vector3 spawnPos = dropPoint != null ? dropPoint.position : transform.position;
        Quaternion spawnRot = prefabToSpawn.transform.rotation;

        Instantiate(prefabToSpawn, spawnPos, spawnRot);
    }

    // Si tu espada usa colisiones físicas
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(weaponTag))
        {
            TakeDamage(damagePerHit);
        }
    }

    // Si tu espada es trigger (IsTrigger en el collider)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(weaponTag))
        {
            TakeDamage(damagePerHit);
        }
    }
}
