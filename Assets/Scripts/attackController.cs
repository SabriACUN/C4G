using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackController : MonoBehaviour
{
    private Animator anim;
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
            StartCoroutine(delayy());
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && canAttack == false)
        {
            anim.Play("secondAttack");
        }
    }
    IEnumerator  delayy()
    {
        yield return new WaitForSeconds(2f);
        anim.Play("idle");
        canAttack = true;
        yield return null;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("vurdum oni");
        }
    }
}
