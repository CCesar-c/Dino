using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obtaclescript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            // morte
        }
    }
}
