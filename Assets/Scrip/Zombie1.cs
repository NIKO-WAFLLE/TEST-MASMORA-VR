using UnityEngine;

public class Zombie1 : MonoBehaviour
{
    [Header("IA")]
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float Grado;

    [Header("Objetivo")]
    public GameObject target;
    public string playerTag = "Player";

    [Header("Movimiento")]
    public float walkSpeed = 1f;
    public float runSpeed = 2f;
    public float distanciaPersecucion = 5f;
    public float distanciaAtaque = 1.5f;

    [Header("Ataque")]
    public float attackCooldown = 1.2f;   // tiempo entre golpes
    private float attackTimer = 0f;       // contador interno
    public string attackStateName = "Slime_Attack";

    public float damage = 10f;         
    private VRPlayerHealth playerHealth; // ? cache del script de vida


    Rigidbody rb;

    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        BuscarPlayerPorTag();

        if (target != null)
            playerHealth = target.GetComponent<VRPlayerHealth>();
    }


    void BuscarPlayerPorTag()
    {
        GameObject p = GameObject.FindGameObjectWithTag(playerTag);
        if (p != null)
            target = p;
        else
            Debug.LogWarning("Zombie1: no encontré ningún objeto con tag " + playerTag);
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;
        Comportamiento_Enemigo();
    }

    public void Comportamiento_Enemigo()
    {
        if (target == null)
        {
            BuscarPlayerPorTag();
            if (target == null)
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
                return;
            }
        }

        float dist = Vector3.Distance(transform.position, target.transform.position);

        if (dist > distanciaPersecucion)
        {
            // Modo patrulla
            ani.SetBool("run", false);
            cronometro += Time.deltaTime;

            if (cronometro > 4f)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0f;
            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    Grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, Grado, 0);
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    Vector3 forwardWalk = transform.forward * walkSpeed * Time.deltaTime;
                    rb.MovePosition(rb.position + forwardWalk);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            // Cerca del jugador
            if (dist > distanciaAtaque)
            {
                // Perseguir
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2f);

                ani.SetBool("walk", false);
                ani.SetBool("run", true);

                Vector3 forwardRun = transform.forward * runSpeed * Time.deltaTime;
                rb.MovePosition(rb.position + forwardRun);
            }
            else
            {
                // Intentar atacar (si cooldown ya terminó)
                ani.SetBool("run", false);
                ani.SetBool("walk", false);

                if (attackTimer <= 0f)
                {
                    ani.SetTrigger("attack"); // dispara la animación de ataque
                    attackTimer = attackCooldown;
                    Debug.Log("[Zombie] lanza ataque");
                }
            }
        }
    }

    // Este método lo sigues llamando desde el AnimationEvent
    // justo donde el golpe conecta
    public void Final_Ani()
    {
        Debug.Log("[Zombie] Final_Ani llamado");
        // Aquí NO tocamos bools, solo podrías apagar el HitBox si quieres
        // Ejemplo: hitBox.SetActive(false);
    }
}
