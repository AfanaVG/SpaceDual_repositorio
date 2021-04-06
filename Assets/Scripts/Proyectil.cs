using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private Rigidbody2D MyRb;
    private float velocidad = 10f;
    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MyRb.velocity = transform.up * velocidad;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemigo" || collision.gameObject.tag == "plataforma")
        {
            Destroy(gameObject);

        }
    }
}
