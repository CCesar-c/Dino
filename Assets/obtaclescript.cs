using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obtaclescript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            print("morri" + Time.timeScale);
        }
    }
}
