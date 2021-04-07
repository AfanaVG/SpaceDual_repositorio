using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumbo : MonoBehaviour
{
    public string color = "";
    public Transform FirePointL; //Posicion de la fuente de disparo
    public Transform FirePointR; //Posicion de la fuente de disparo
    public float velocidad = 1f;
    public GameObject balaL; //Objeto proyectil que usaremos para crear los proyectiles
    public GameObject balaR; //Objeto proyectil que usaremos para crear los proyectiles
    private bool puedeDisparar = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, -velocidad * Time.deltaTime, 0);
        if (puedeDisparar)
        {
            StartCoroutine("Disparar");
        }
        
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "ProyectilRojo" && color.Equals("rojo"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Tocado");

            Destroy(gameObject, 0.2f);
        }
        if (collision.gameObject.tag == "ProyectilAzul" && color.Equals("azul"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Tocado");

            Destroy(gameObject, 0.2f);
        }
    }

    IEnumerator Disparar()
    {
        puedeDisparar = false;
        yield return new WaitForSeconds(1f);

        FirePointL.eulerAngles = new Vector3(0, 0, 0);
        Instantiate(balaL, FirePointL.position, FirePointL.rotation);

        FirePointR.eulerAngles = new Vector3(0, 0, 0);
        Instantiate(balaR, FirePointR.position, FirePointR.rotation);
        puedeDisparar = true;
    }
}
