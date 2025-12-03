using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerarpisos : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("gerarlospisos");
    }

    IEnumerator gerarlospisos()
    {
        yield return new WaitForSeconds(2);
        GameObject clonePiso = Instantiate(target, target.transform.position, target.transform.rotation);
    }
}
