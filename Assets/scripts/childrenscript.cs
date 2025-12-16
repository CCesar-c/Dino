using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childrenscript : MonoBehaviour
{
    public GameObject target;
    public GameObject Pedra;
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
        while (creados <= 0)
        {
            yield return new WaitForSeconds(0f);

            var parent = Instantiate(target, new Vector2(target.transform.position.x + 20, target.transform.position.y), target.transform.rotation);
            creados = 1;
            yield return new WaitForSeconds(30);
            DestroyImmediate(target.gameObject);
        }
    }
}
