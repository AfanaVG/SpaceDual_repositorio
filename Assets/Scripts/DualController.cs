using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualController : MonoBehaviour
{
    //Este objeto es la nave Dual que sera el jugador

    public AudioClip[] disparos;
    public AudioClip explosion;
    private AudioClip disparoAnterior;
    public GameObject[] proyectiles; //Array de objetos proyectil que usaremos para generar los proyectiles
    public float velocidad = 5; //Velocidad de movimiento de la nave en todos los angulos
    private bool puedeDisparar = true; //Booleano para crear el espacio de tiempo entre disparos
    public Transform FirePoint; //Posicion de la fuente de disparo
    private int proyectil_seleccionado =0; //Indica que proyectil esta listo para ser disparado
    public int restaPuntos = 0; //Cantidad de puntos que se pierden al recibir un impacto

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento(); //Controlara el movimiento de la nave
        Disparo(); //Maneja tanto el disparo como el sistema de seleccion de balas

        
    }

    //Controla el tiempo entre disparos
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.3f);
        puedeDisparar = true;
    }

    IEnumerator EsperarExplosion()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<AudioSource>().clip = disparoAnterior;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si recibimos un golpe perdemos puntos
        if (collision.gameObject.tag.Equals("Enemigo") || collision.gameObject.tag.Equals("Bala"))
        {
            GameController.Puntuacion += -restaPuntos;
            gameObject.GetComponent<Animator>().SetTrigger("Tocado");

             disparoAnterior = gameObject.GetComponent<AudioSource>().clip;
            gameObject.GetComponent<AudioSource>().clip = explosion;
            gameObject.GetComponent<AudioSource>().Play();

            StartCoroutine("EsperarExplosion");
            


        }
    }

    private void Disparo()
    {
        if (Input.GetKey(KeyCode.Space) && puedeDisparar)
        {
            
            gameObject.GetComponent<AudioSource>().Play();
            puedeDisparar = false;
            FirePoint.eulerAngles = new Vector3(0, 0, 0);
            Instantiate(proyectiles[proyectil_seleccionado], FirePoint.position, FirePoint.rotation);
            StartCoroutine("Esperar");
        }
       

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            
            if (proyectil_seleccionado != proyectiles.Length - 1)
            {
                proyectil_seleccionado++;
            }
            else
            {
                proyectil_seleccionado = 0;
            }
            if (proyectil_seleccionado == 1)
            {
                GameController.TipoProyectil = "ROJO";
                gameObject.GetComponent<AudioSource>().clip = disparos[1];
            }
            else
            {
                GameController.TipoProyectil = "AZUL";
                gameObject.GetComponent<AudioSource>().clip = disparos[0];
            }

        }

    }

    private void Movimiento()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(-velocidad * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(velocidad * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.Translate(0, velocidad * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Translate(0, -velocidad * Time.deltaTime, 0);
        }

    }

}
