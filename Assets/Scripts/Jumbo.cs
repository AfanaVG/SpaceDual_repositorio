using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jumbo : MonoBehaviour
{
    //Objeto Jumbo que corresponde a un enemigo

    public string color = ""; //Indica el color del enemigo; Valores aceptado : rojo | azul
    public Transform FirePointL; //Posicion de la fuente de disparo izquierda
    public Transform FirePointR; //Posicion de la fuente de disparo derecha
    public float velocidad = 1f; //Velocidad de la nave
    public GameObject balaL; //Objeto proyectil que usaremos para crear los proyectiles izquierdos
    public GameObject balaR; //Objeto proyectil que usaremos para crear los proyectiles derechos
    private bool puedeDisparar = true; //Booleano para crear el espacio de tiempo entre disparos
    public int puntuacion=0; //Puntuacion que dara el enemigo al ser destruido
    private bool disparoActivado = false;
    public AudioClip explosion;
    public AudioClip impactoFallido;
    public AudioClip disparo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Movimiento(); //Controlara el movimiento de la nave
        Disparo(); //Controla el disparo de la nave


    }

    private void Movimiento()
    {
        gameObject.transform.Translate(0, -velocidad * Time.deltaTime, 0);
    }

    private void Disparo()
    {
        if (puedeDisparar && disparoActivado)//Disparara si a pasado el tiempo suficiente
        {
            StartCoroutine("Disparar");
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Dependiendo del proyectil que impacte la nave saldra ilesa o sera destruida

        if (collision.gameObject.tag == "ProyectilRojo" && color.Equals("rojo"))
        {
            Golpeado();
        }
        else if (collision.gameObject.tag == "ProyectilAzul" && color.Equals("azul"))
        {
            Golpeado();
        }

        if (collision.gameObject.tag == "ProyectilRojo" && !color.Equals("rojo"))
        {
            gameObject.GetComponent<AudioSource>().clip = impactoFallido;
            gameObject.GetComponent<AudioSource>().volume = 1f;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (collision.gameObject.tag == "ProyectilAzul" && !color.Equals("azul"))
        {
            gameObject.GetComponent<AudioSource>().clip = impactoFallido;
            gameObject.GetComponent<AudioSource>().volume = 1f;
            gameObject.GetComponent<AudioSource>().Play();
        }

        if (collision.gameObject.tag == "Destructor")
        {
            
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Limite")
        {
            disparoActivado = true;

        }
    }

    private void Golpeado()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Tocado");
        GameController.Puntuacion += puntuacion;
        gameObject.GetComponent<AudioSource>().clip = explosion;
        gameObject.GetComponent<AudioSource>().volume = 1.0f;
        gameObject.GetComponent<AudioSource>().Play();
        Destroy(gameObject, 0.2f);
    }

    IEnumerator Disparar()
    {
        puedeDisparar = false;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<AudioSource>().clip = disparo;
        gameObject.GetComponent<AudioSource>().volume = 0.2f;
        gameObject.GetComponent<AudioSource>().Play();

        FirePointL.eulerAngles = new Vector3(0, 0, 0);
        Instantiate(balaL, FirePointL.position, FirePointL.rotation);

        FirePointR.eulerAngles = new Vector3(0, 0, 0);
        Instantiate(balaR, FirePointR.position, FirePointR.rotation);
        puedeDisparar = true;
    }
}
