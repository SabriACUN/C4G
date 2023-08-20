using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using OpenCover.Framework.Model;

public class test : MonoBehaviour
{
    public Transform cameraTransform; // Sallanacak kameranın Transform bileşeni
    public float duration = 0.5f; // Sallanma süresi
    public float strength = 0.5f; // Sallanma şiddeti

    void Start()
    {
        // Kamerayı orijinal pozisyonundan sallayın
    }


    public void Shke()
    {
        cameraTransform.DOShakePosition(duration, strength).OnComplete(Method);
        
        cameraTransform.GetComponent<Animator>().enabled = false;


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // cameraTransform.DOShakePosition(duration, strength);
            cameraTransform.GetComponent<Animator>().SetTrigger("Cam2");


        }
    }

    void Method()
    {
        cameraTransform.GetComponent<Animator>().enabled = true;
        cameraTransform.GetComponent<Animator>().SetTrigger("Cam2");


    }
}