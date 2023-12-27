using UnityEngine;

public class EnemyFireballHolder : MonoBehaviour
{
    [SerializeField] private Transform enemy;

    private void Update()
    {
        Vector3 direction = new Vector3(-enemy.localScale.x, enemy.localScale.y, enemy.localScale.z);

        transform.localScale = direction;
    }
}