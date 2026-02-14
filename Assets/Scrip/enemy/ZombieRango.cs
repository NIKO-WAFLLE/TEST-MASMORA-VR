using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animation))]
public class ZombieRango : MonoBehaviour
{
    [Header("Movimiento")]
    public NavMeshAgent zombie;
    public float velocidad = 1.5f;
    public float rango = 5.0f;
    public float distancia;
    public bool persiguiendo;

    public Transform objetivo;

    [Header("Animaciones (Legacy)")]
    public Animation anim;                 // se autoasigna si está vacío
    public AnimationClip clipCaminar;      // arrastra aquí "Walking"
    public AnimationClip clipQuieto;       // arrastra aquí "Quieto"

    void Awake()
    {
        if (!zombie) zombie = GetComponent<NavMeshAgent>();
        if (!anim) anim = GetComponent<Animation>();

        // Registrar clips en el componente Animation para que existan los "states"
        if (clipQuieto && anim.GetClip(clipQuieto.name) == null) anim.AddClip(clipQuieto, clipQuieto.name);
        if (clipCaminar && anim.GetClip(clipCaminar.name) == null) anim.AddClip(clipCaminar, clipCaminar.name);
    }

    void Update()
    {
        if (!objetivo || !zombie || !anim) return;

        distancia = Vector3.Distance(zombie.transform.position, objetivo.position);
        persiguiendo = (distancia < rango) ? true : (distancia > rango + 3 ? false : persiguiendo);

        if (!persiguiendo)
        {
            zombie.speed = 0f;
            if (clipQuieto) anim.CrossFade(clipQuieto.name);
        }
        else
        {
            zombie.speed = velocidad;
            if (clipCaminar) anim.CrossFade(clipCaminar.name);
            zombie.SetDestination(objetivo.position);
        }
    }

    void OnDrawGizmos()
    {
        if (zombie) { Gizmos.color = Color.red; Gizmos.DrawWireSphere(zombie.transform.position, rango); }
    }
}
