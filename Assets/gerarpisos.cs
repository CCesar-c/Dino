using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class gerarpisos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("gerarlospisos");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.004f, -5);
    }
    int creados;

    IEnumerator gerarlospisos()
    {

        while (true && creados <= 0)
        {
            yield return new WaitForSeconds(20);
            GameObject target = this.gameObject;
            Instantiate(target, new Vector2(target.transform.position.x + 10, target.transform.position.y), target.transform.rotation);
            creados = 1;
            yield return new WaitForSeconds(60);
            DestroyImmediate(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject children = GetComponentInChildren<GameObject>();
    }
}
