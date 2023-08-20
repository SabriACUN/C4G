using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afterJumpAnim : MonoBehaviour
{
    public Camera cam;
    public GameObject golge,main;
    public MeshRenderer cpmesh;
    private void OnTriggerEnter(Collider other)
    {
        cam.gameObject.SetActive(true);
        golge.SetActive(true);
        main.SetActive(false);
        cpmesh.enabled = false;
        StartCoroutine(bekle());
    }

    public IEnumerator bekle()
    {
        yield return new WaitForSeconds(8f);
        cam.gameObject.SetActive(false);
        golge.gameObject.SetActive(false);
        cpmesh.enabled=true;
        main.SetActive(true);
    }
}
