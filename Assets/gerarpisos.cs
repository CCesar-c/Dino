using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class gerarpisos : MonoBehaviour
{

    void Update()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.004f, -5);
    }
}
