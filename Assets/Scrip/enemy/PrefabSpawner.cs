using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [Header("Prefabs a elegir")]
    public GameObject[] prefabs;   // Arrastras aquí 1 o varios prefabs

    [Header("Punto donde aparecerán")]
    public Transform spawnPoint;   // Arrastra aquí un GameObject vacío como posición
                                   // Si lo dejas vacío, usará la posición de este mismo objeto

    [Header("Configuración")]
    public bool aleatorio = true;  // Si es true, elige un prefab al azar
    public int indiceFijo = 0;     // Si aleatorio = false, usa este índice del arreglo

    private void Start()
    {
        if (prefabs == null || prefabs.Length == 0)
        {
            Debug.LogWarning("[PrefabSpawner] No hay prefabs asignados.");
            return;
        }

        // Definir punto de aparición
        Transform punto = spawnPoint != null ? spawnPoint : transform;

        GameObject prefabAInstanciar;

        if (aleatorio)
        {
            int index = Random.Range(0, prefabs.Length);
            prefabAInstanciar = prefabs[index];
        }
        else
        {
            // Asegurarnos de no salirnos del arreglo
            int index = Mathf.Clamp(indiceFijo, 0, prefabs.Length - 1);
            prefabAInstanciar = prefabs[index];
        }

        if (prefabAInstanciar != null)
        {
            Instantiate(prefabAInstanciar, punto.position, punto.rotation);
        }
        else
        {
            Debug.LogWarning("[PrefabSpawner] El prefab seleccionado es null.");
        }
    }
}
