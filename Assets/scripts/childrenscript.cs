using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childrenscript : MonoBehaviour
{
    public GameObject target;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(nameof(gerarlospisos));
        }
    }
    int creados;

    public IEnumerator gerarlospisos()
    {

        while (true && creados <= 0)
        {
            yield return new WaitForSeconds(3.5f);

            Instantiate(target, new Vector2(target.transform.position.x + 20, target.transform.position.y), target.transform.rotation);
            creados = 1;
            yield return new WaitForSeconds(30);
            DestroyImmediate(target.gameObject);
        }
    }
}
