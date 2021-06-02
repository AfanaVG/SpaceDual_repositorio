using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    //Objeto Stand que corresponde a un enemigo

    public string color = ""; //Indica el color del enemigo; Valores aceptado : rojo | azul
    public float velocidad = 1f; //Velocidad de la nave
    public float v_lateral = 5f; //Velocidad lateral de la nave
    public float dist_lateral = 3f; //Distancia del movimiento hacia los lados de la nave
    private Vector3 posicionInicial; //La posicion inicial de la nave
    private int paso = 1; // Variable para controlar el orden del movimiento lateral
    public int puntuacion = 0; //Puntuacion que dara el enemigo al ser destruido

    // Start is called before the first frame update
    void Start()
    {

        posicionInicial = gameObject.GetComponent<Transform>().position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento(); //Controlara el movimiento de la nave y el movimiento lateral

    }

    private void Movimiento()
    {
        gameObject.transform.Translate(0, -velocidad * Time.deltaTime, 0); //Movimiento hacia delante


        
        if (posicionInicial.x + dist_lateral > gameObject.GetComponent<Transform>().position.x && paso == 1)
        {
            gameObject.transform.Translate(v_lateral * Time.deltaTime, 0, 0);
            if (gameObject.GetComponent<Transform>().position.x >= posicionInicial.x + dist_lateral)
            {
                paso = 2;
            }

        }

        if (posicionInicial.x - dist_lateral < gameObject.GetComponent<Transform>().position.x && paso == 2)
        {
            gameObject.transform.Translate(-v_lateral * Time.deltaTime, 0, 0);

            if (gameObject.GetComponent<Transform>().position.x <= posicionInicial.x - dist_lateral)
            {
                paso = 1;
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Dependiendo del proyectil que impacte la nave saldra ilesa o sera destruida

        if (collision.gameObject.tag == "ProyectilRojo" && color.Equals("rojo"))
        {
            Golpeado();
        }
        if (collision.gameObject.tag == "ProyectilAzul" && color.Equals("azul"))
        {
            Golpeado();
        }
        if (collision.gameObject.tag == "Destructor")
        {
            Destroy(gameObject);
        }
    }

    private void Golpeado()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Tocado");
        GameController.Puntuacion += puntuacion;
        Destroy(gameObject, 0.2f);
    }
}
