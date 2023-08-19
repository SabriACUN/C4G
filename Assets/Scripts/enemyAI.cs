using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyAI : MonoBehaviour
{
    public Transform player; // Oyuncu'nun Transform bileþeni
    public float followRange = 10f; // Takip menzili
    public float attackRange = 2f; // Saldýrý menzili
    public float attackCooldown = 2f; // Saldýrý aralýðý

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

        // Oyuncu takip menzili içindeyse
        if (distanceToPlayer <= followRange && !isDeath)
        {
            // Oyuncuya doðru ilerle
            agent.SetDestination(player.position);

            // Oyuncu saldýrý menzili içindeyse ve saldýrý aralýðý dolmuþsa
            if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
            {
                // Saldýrý yap
                Attack();
                nextAttackTime = Time.time + attackCooldown; // Saldýrý aralýðýný ayarla
            }
        }
    }

    void Attack()
    {
        // Saldýrý kodunu buraya ekleyin
        // Örneðin, oyuncuya hasar verme kodunu burada yazabilirsiniz.
        // Dikkat: Saldýrý hýzý ve hasar miktarýný ayarlamayý unutmayýn.

        // Saldýrý animasyonunu oynatmak için Animator'i kullanabilirsiniz.
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
