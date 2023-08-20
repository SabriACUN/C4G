using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDoorManager : MonoBehaviour
{
    public GameObject door;
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
            door.transform.Rotate(0, -1, 0);
            doorAngle++;
        }
    }
}
