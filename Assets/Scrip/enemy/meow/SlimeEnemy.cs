using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    private void Start()
    {
        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.RegisterEnemy();
        }
    }
}
