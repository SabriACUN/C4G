using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloser : MonoBehaviour
{
    public GameObject doorRight;
    public GameObject doorLeft;
    private bool isDoorOpen = true;
    private int doorAngle = 90;

    private void OnTriggerEnter(Collider other)
    {
        isDoorOpen = false;
    }

    private void FixedUpdate()
    {
        if (!isDoorOpen && doorAngle > 0)
        {
            doorRight.transform.Rotate(0, -1, 0);
            doorLeft.transform.Rotate(0, 1, 0);
            doorAngle--;
        }
    }
}
