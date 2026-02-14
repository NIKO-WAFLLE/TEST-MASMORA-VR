using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class LoadSceneOnPress : MonoBehaviour
{
    [Header("Nombre de la escena a cargar")]
    public string sceneName;

    [Header("Interactable del botón")]
    public XRSimpleInteractable interactable;

    void Awake()
    {
        // Si no se asigna en el Inspector, intenta tomarlo del mismo objeto
        if (interactable == null)
            interactable = GetComponent<XRSimpleInteractable>();

        if (interactable != null)
            interactable.selectEntered.AddListener(OnButtonPressed);
        else
            Debug.LogWarning("No se encontró XRSimpleInteractable para LoadSceneOnPress.");
    }

    void OnDestroy()
    {
        if (interactable != null)
            interactable.selectEntered.RemoveListener(OnButtonPressed);
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        // Carga directa por nombre
        SceneManager.LoadScene(sceneName);
    }

    // Método opcional por si prefieres usar UnityEvent en el Inspector
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
