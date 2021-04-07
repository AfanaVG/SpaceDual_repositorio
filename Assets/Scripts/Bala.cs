using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody2D MyRb;
    private float velocidad = 5;
    public string direccion="";



    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (direccion.Equals("izquierda"))
        {
            MyRb.velocity =  transform.right * -velocidad;
        }

        if (direccion.Equals("derecha"))
        {
            MyRb.velocity = transform.right * velocidad;
        }
        
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dual" || collision.gameObject.tag == "plataforma")
        {
            Destroy(gameObject);

        }
    }
}
