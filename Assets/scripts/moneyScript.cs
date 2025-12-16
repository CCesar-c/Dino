using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyScript : MonoBehaviour
{
    void Start()
    {
        if (transform.parent != null)
        {
            Transform ParentT = transform.parent.gameObject.transform;
            this.transform.position = new Vector2(ParentT.position.x + UnityEngine.Random.Range(-5, 5), ParentT.position.y + UnityEngine.Random.Range(1, 2));
            this.transform.SetParent(ParentT, false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.MoneyCount += 1;
            Destroy(this.gameObject);
        }
    }
}
