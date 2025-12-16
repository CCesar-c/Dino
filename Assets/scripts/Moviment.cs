using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Moviment : MonoBehaviour
{
    ParticleSystem ps;
    Rigidbody2D rb;
    public float moveForce = 20f;
    public float jumpForce = 8f;
    public bool isPiso;
    public bool estoyVivo = true;
    public int tim;

    void Start()
    {
        StartCoroutine(nameof(Relog));
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
        ps.Stop();

    }
    Vector2 calculo = Vector2.right;
    public float maxSpeed = 10f;
    public void onClickJump()
    {
        if (!estoyVivo) return;
        if (isPiso && estoyVivo)
        {
            rb.AddForce(calculo.normalized * 0.25f, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up.normalized * jumpForce, ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        if (!estoyVivo) return;

        // Movimiento automático
        rb.AddForce(calculo.normalized * moveForce, ForceMode2D.Force);

        rb.velocity = new Vector2(
            Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed),
            rb.velocity.y
        );

        if (isPiso && estoyVivo && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(calculo.normalized * 0.25f, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up.normalized * jumpForce, ForceMode2D.Impulse);
        }
    }
    void LateUpdate()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            GameObject text_time = GameObject.Find("Text0");


            GameObject text_Bestime = GameObject.Find("Text1");

            for (int i = 0; i < GameManager.instance.lista.players.Length; i++)
            {
                if (GameManager.instance.lista.players[i].name == GameManager.instance.Nome)
                {
                    text_Bestime.GetComponent<Text>().text = "Best score: " + GameManager.instance.lista.players[i].score;
                }
            }
            text_time.GetComponent<Text>().text = tim.ToString("score: " + tim);
        }
    }
    public void GobackScene()
    {
        SceneManager.LoadScene("home");
    }
    public void reloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("piso"))
        { isPiso = true; }
        if (collision.gameObject.CompareTag("pedra"))
        {
            estoyVivo = false;
            ps.Play();

            GameObject panel = GameObject.Find("Panel");
            panel.gameObject.transform.localScale = new Vector3(1, 1, 1);
            GameManager.instance.StartUpdateMoney();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("piso"))
        { isPiso = false; }
    }
    IEnumerator Relog()
    {
        while (estoyVivo)
        {
            yield return new WaitForSeconds(1);
            tim += 1;
        }
    }
}
