using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pisoscript : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.002f, -5);
    }
}
