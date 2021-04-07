using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualController : MonoBehaviour
{
    public GameObject[] proyectiles; //Objeto proyectil que usaremos para crear los proyectiles
    public GameObject proyectil; //Objeto proyectil que usaremos para crear los proyectiles
    public float velocidad = 5; //Velocidad de movimiento de la nave en todos los angulos
    private bool puedeDisparar = true; //Booleano para crear el espacio entre disparos
    public Transform FirePoint; //Posicion de la fuente de disparo
    private int proyectil_seleccionado =0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

        if (Input.GetKey(KeyCode.Space)  && puedeDisparar)
        {
            puedeDisparar = false;
            FirePoint.eulerAngles = new Vector3(0, 0, 0);
            Instantiate(proyectiles[proyectil_seleccionado], FirePoint.position, FirePoint.rotation);
            StartCoroutine("Esperar");
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {

            if (proyectil_seleccionado != proyectiles.Length-1)
            {
                proyectil_seleccionado++;
            }
            else
            {
                proyectil_seleccionado = 0;
            }
            
        }
    }

    //Controla el tiempo entre disparos
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.3f);
        puedeDisparar = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemigo") || collision.gameObject.tag.Equals("Bala"))
        {
            

            gameObject.GetComponent<Animator>().SetTrigger("Tocado");
        }
    }

}
