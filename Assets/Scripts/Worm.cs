using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    //Objeto Worm que corresponde a un enemigo

    public string color = ""; //Indica el color del enemigo; Valores aceptado : rojo | azul
    public float velocidad = 1f; //Velocidad de la nave
    public int puntuacion = 0; //Puntuacion que dara el enemigo al ser destruido
    public AudioClip explosion;
    public AudioClip impactoFallido;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, -velocidad * Time.deltaTime, 0);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Dependiendo del proyectil que impacte la nave saldra ilesa o sera destruida

        if (collision.gameObject.tag == "ProyectilRojo" && color.Equals("rojo"))
        {
            Golpeado();
        }else if (collision.gameObject.tag == "ProyectilAzul" && color.Equals("azul"))
        {
            Golpeado();
        }

        if (collision.gameObject.tag == "ProyectilRojo" && !color.Equals("rojo"))
        {
            gameObject.GetComponent<AudioSource>().clip = impactoFallido;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (collision.gameObject.tag == "ProyectilAzul" && !color.Equals("azul"))
        {
            gameObject.GetComponent<AudioSource>().clip = impactoFallido;
            gameObject.GetComponent<AudioSource>().Play();
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
        gameObject.GetComponent<AudioSource>().clip = explosion;
        gameObject.GetComponent<AudioSource>().Play();
        Destroy(gameObject, 0.2f);
    }
}
