using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moviment : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 50;
    bool isPiso;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 30;

        if (isPiso && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * force + transform.right * (force / 10));
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("piso"))
        {
            isPiso = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("piso"))
        {
            isPiso = false;
        }
    }

}
