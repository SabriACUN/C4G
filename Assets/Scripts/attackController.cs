using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackController : MonoBehaviour
{
    public GameObject hitPoint;
    private Animator anim;
    private RaycastHit hit;
    private bool canAttack = true;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            canAttack = false;
            anim.Play("firstAttack");

            // Raycast'i çýkart
            StartCoroutine(attack());
            StartCoroutine(delayy());
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && canAttack == false)
        {
            anim.Play("secondAttack");
            StartCoroutine(attack());
            StartCoroutine(delayy());
        }
    }
    IEnumerator attack()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 raycastOrigin = hitPoint.transform.position;
        Vector3 raycastDirection = hitPoint.transform.forward;
        if (Physics.Raycast(raycastOrigin, raycastDirection, out hit,3f))
        {
            if(hit.collider)
                hit.collider.gameObject.GetComponent<enemyAI>().takeDamage();
        }
    }

    IEnumerator delayy()
    {
        yield return new WaitForSeconds(2f);
        anim.Play("idle");
        canAttack = true;
        yield return null;
    }
}
