using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyAI : MonoBehaviour
{
    public Transform player; // Oyuncu'nun Transform bile�eni
    public float followRange = 10f; // Takip menzili
    public float attackRange = 2f; // Sald�r� menzili
    public float attackCooldown = 2f; // Sald�r� aral���
    public GameObject crumbling;

    private int health = 3;
    private bool isDeath;
    private NavMeshAgent agent;
    private Animator animator;
    private float nextAttackTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0 && !isDeath)
        {
            isDeath = true;
            // �l�m animasyonunu oynat
            //animator.SetTrigger("Death");

            // Crumbling objesini instantiate et
            Instantiate(crumbling, transform.position, transform.rotation);

            // Karakteri devre d��� b�rak
            gameObject.SetActive(false);
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Oyuncu takip menzili i�indeyse ve karakter �lmediyse
        if (distanceToPlayer <= followRange && !isDeath)
        {
            // Oyuncuya do�ru ilerle
            agent.SetDestination(player.position);

            // Oyuncu sald�r� menzili i�indeyse ve sald�r� aral��� dolmu�sa
            if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
            {
                // Sald�r� yap
                Attack();
                nextAttackTime = Time.time + attackCooldown; // Sald�r� aral���n� ayarla
            }
        }
        else
        {
            // Oyuncu takip menzili d���ndaysa, karakter y�r�me animasyonunu oynat
            animator.SetBool("IsWalking", true);
        }
    }

    void Attack()
    {
        // Sald�r� kodunu buraya ekleyin
        // �rne�in, oyuncuya hasar verme kodunu burada yazabilirsiniz.
        // Dikkat: Sald�r� h�z� ve hasar miktar�n� ayarlamay� unutmay�n.

        // Sald�r� animasyonunu oynatmak i�in Animator'i kullanabilirsiniz.
        animator.SetTrigger("Attack");
    }

    public void takeDamage()
    {
        health -= 1;
    }
}
