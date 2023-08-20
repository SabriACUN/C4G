using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject doorRight;
    public GameObject doorLeft;
    private bool isDoorOpen = false;
    private int doorAngle = 0;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("FBI Open the Door");
        isDoorOpen = true;
    }

    private void FixedUpdate()
    {
        if (isDoorOpen && doorAngle < 90)
        {
            doorRight.transform.Rotate(0, 1, 0);
            doorLeft.transform.Rotate(0, -1, 0);
            doorAngle++;
        }
    }
}
