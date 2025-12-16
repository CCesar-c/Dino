using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piedraScript : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            if (transform.parent != null)
            {
                Transform ParentT = transform.parent.gameObject.transform;
                this.transform.position = new Vector2(ParentT.position.x + UnityEngine.Random.Range(1, 5), -2.75f);
                this.transform.localScale = new Vector2(0.04f, UnityEngine.Random.Range(0.75f, 1.75f));
                this.transform.SetParent(ParentT, true);
            }
        }
    }
}