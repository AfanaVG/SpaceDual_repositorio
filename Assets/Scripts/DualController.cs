using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private static GameObject dual;
    private static DualController dualScript;



    

    // Start is called before the first frame update
    void Start()
    {
        dual = FindObjectOfType<DualController>().gameObject;
        dualScript = FindObjectOfType<DualController>();

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento(); //Controlara el movimiento de la nave
        ControlProyectiles(); //Maneja tanto el disparo como el sistema de seleccion de balas

        
    }

    //Controla el tiempo entre disparos
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.3f);
        dualScript.puedeDisparar = true;
    }

    IEnumerator EsperarExplosion()
    {
        yield return new WaitForSeconds(0.1f);
        dual.GetComponent<AudioSource>().clip = dualScript.disparoAnterior;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si recibimos un golpe perdemos puntos
        if (collision.gameObject.tag.Equals("Enemigo") || collision.gameObject.tag.Equals("Bala"))
        {
            GameController.Puntuacion += dualScript.restaPuntos;
            dual.GetComponent<Animator>().SetTrigger("Tocado");

            disparoAnterior = dual.GetComponent<AudioSource>().clip;
            dual.GetComponent<AudioSource>().clip = dualScript.explosion;
            dual.GetComponent<AudioSource>().Play();
            
            StartCoroutine("EsperarExplosion");
            


        }

        if (collision.gameObject.tag.Equals("Final"))
        {
            SceneManager.LoadScene("Cortinilla");
        }
    }

    private void ControlProyectiles()
    {
        if (Input.GetKey(KeyCode.Space) && dualScript.puedeDisparar)
        {

            Disparo();
        }
       

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {

            CambiarProyectil();

        }

    }

    public void Disparo()
    {
        dual.GetComponent<AudioSource>().Play();
        dualScript.puedeDisparar = false;
        dualScript.FirePoint.eulerAngles = new Vector3(0, 0, 0);
        Instantiate(dualScript.proyectiles[dualScript.proyectil_seleccionado], dualScript.FirePoint.position, dualScript.FirePoint.rotation);
        dualScript.StartCoroutine("Esperar");
        //StartCoroutine("Esperar");
    }

    public void CambiarProyectil()
    {
        Debug.Log(dualScript.proyectil_seleccionado);

        if (dualScript.proyectil_seleccionado != dualScript.proyectiles.Length - 1)
        {
            dualScript.proyectil_seleccionado++;
            
        }
        else
        {
            dualScript.proyectil_seleccionado = 0;
        }

        if (dualScript.proyectil_seleccionado == 1)
        {
            GameController.TipoProyectil = "ROJO";
            dual.GetComponent<AudioSource>().clip = dualScript.disparos[1];
        }
        else
        {
            GameController.TipoProyectil = "AZUL";
            dual.GetComponent<AudioSource>().clip = dualScript.disparos[0];
        }
    }

    private void Movimiento()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MovIzquierda();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MovDerecha();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            MovArriba();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            MovAbajo();
        }

    }

    public void MovDerecha()
    {
        dual.transform.Translate(velocidad * Time.deltaTime, 0, 0);
    }

    public void MovIzquierda()
    {
        dual.transform.Translate(-velocidad * Time.deltaTime, 0, 0);
    }

    public void MovArriba()
    {
        Debug.Log("Hello World");
        dual.transform.Translate(0, velocidad * Time.deltaTime, 0);
        //transform.Translate(0, velocidad * Time.deltaTime, 0);
    }

    public void MovAbajo()
    {
        dual.transform.Translate(0, -velocidad * Time.deltaTime, 0);
    }

}
