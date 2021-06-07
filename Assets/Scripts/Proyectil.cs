using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    
    private float velocidad = 13f; //Velocidad del disparo
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento(); // Metodo que controla el movimiento del proyectil

        Destroy(gameObject, 5f); //Despues de 5s la bala desaparecera para evitar sobrecargar el sistema
    }

    private void Movimiento()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * velocidad;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el proyectil impacta contra un enemigo o contra un limite de pantalla la desaparecera
        if (collision.gameObject.tag == "Enemigo" || collision.gameObject.tag == "Limite")
        {
            Destroy(gameObject);

        }
    }
}
