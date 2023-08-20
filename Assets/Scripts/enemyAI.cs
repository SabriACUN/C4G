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

        if(health <= 0)
        {
            isDeath = true;
            Destroy(gameObject);
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Oyuncu takip menzili i�indeyse
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
    }

    void Attack()
    {
        // Sald�r� kodunu buraya ekleyin
        // �rne�in, oyuncuya hasar verme kodunu burada yazabilirsiniz.
        // Dikkat: Sald�r� h�z� ve hasar miktar�n� ayarlamay� unutmay�n.

        // Sald�r� animasyonunu oynatmak i�in Animator'i kullanabilirsiniz.
       animator.SetTrigger("Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("axe"))
        {
            health -= 1;
        }

    }
}
