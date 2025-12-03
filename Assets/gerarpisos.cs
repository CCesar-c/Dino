using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class gerarpisos : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("gerarlospisos");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator gerarlospisos()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            float valor = UnityEngine.Random.Range(1, 10);
            if (valor >= 7)
            {
                GameObject clonePiso = Instantiate(target, target.transform.position, target.transform.rotation);
            }
        }
    }
}
