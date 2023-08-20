using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDoorCloser : MonoBehaviour
{
    public GameObject door;
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
            door.transform.Rotate(0, 1, 0);
            doorAngle--;
        }
    }
}
