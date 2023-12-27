using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform ShootingPoint;
    [SerializeField] private GameObject[] blast;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;

        blast[FindFireball()].transform.position = ShootingPoint.position;
        blast[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindFireball()
    {
        for (int i = 0; i < blast.Length; i++)
        {
            if (!blast[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}