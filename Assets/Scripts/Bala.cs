using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    //Objeto Bala que corresponde a un ataque a distancia del enemigo Jumbo
    
    public float velocidad = 5; //Velocidad a la que ira la bala
    public string direccion=""; //Define la direccion de la bala; Valores aceptado: izquierda | derecha



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento(); // Metodo que controla la direccion de la bala dependiendo del valor de la variable direccion


        Destroy(gameObject, 20f); //Despues de 5s la bala desaparecera para evitar sobrecargar el sistema
    }

    private void Movimiento()
    {
        if (direccion.Equals("izquierda"))
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * -velocidad;
        }

        if (direccion.Equals("derecha"))
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * velocidad;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si la bala impacta contra nuestro personaje o contra un limite de pantalla la desaparecera
        if (collision.gameObject.tag == "Dual" || collision.gameObject.tag == "Limite")
        {
            Destroy(gameObject);

        }
    }
}
