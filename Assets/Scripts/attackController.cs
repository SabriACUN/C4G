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
        //if (anim.GetCurrentAnimatorStateInfo(0).IsName("firstAttack") && anim.GetCurrentAnimatorStateInfo(0).IsName("secondAttack")) return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {

            canAttack = false;
            anim.SetBool("first", true);

            // Raycast'i çýkart
            StartCoroutine(attack());
            StartCoroutine(delayy());
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && canAttack == false)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("secondAttack")) return;
            anim.SetBool("second", true);
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
        yield return new WaitForSeconds(1f);
        anim.SetBool("first", false);
        anim.SetBool("second", false);

        canAttack = true;
        yield return null;
    }
}
