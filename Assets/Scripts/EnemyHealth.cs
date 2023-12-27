using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{ 
    private Rigidbody2D rb;
    private Animator anim;
    public float maxHealth = 10;
    public float currentHealth;
    bool dead;

    EnemyPatrol enemyPatrol;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        if (currentHealth > 0)
        {
            StartCoroutine(Invunerability());
            anim.SetTrigger("hit");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("death");
                if (GetComponentInParent<EnemyPatrol>() != null)
                {
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                    //Destroy(transform.parent.gameObject);
                    //Destroy(gameObject);
                    
                }
                dead = true;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blast"))
        {
            TakeDamage(4);
        }
    }
    private IEnumerator Invunerability()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
