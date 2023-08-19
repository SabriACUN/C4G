using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class shakerr : MonoBehaviour
{
    public bool start = false;
    public float duration = 1f;


    void Start()
    {
        StartCoroutine(Shaking());
    }
    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elepsedTime = 0f;

        while (elepsedTime < duration)
        {
            elepsedTime += Time.deltaTime;
            transform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }
        transform.position = startPosition;
    }

}
