using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moviment_fondo : MonoBehaviour
{
    public float force = 10;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        gameObject.transform.position = new Vector2(player.gameObject.transform.position.x - force, player.gameObject.transform.position.y - force);
    }
}
