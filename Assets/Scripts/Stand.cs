using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public string color = "";
    public float velocidad = 1f;
    public float v_lateral = 5f;
    public float dist_lateral = 3f;
    private Vector3 posicionInicial;
    private int paso = 1;
    // Start is called before the first frame update
    void Start()
    {

        posicionInicial = gameObject.GetComponent<Transform>().position;
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, -velocidad * Time.deltaTime, 0);


        if (posicionInicial.x + dist_lateral > gameObject.GetComponent<Transform>().position.x && paso == 1)
        {
            gameObject.transform.Translate(v_lateral * Time.deltaTime, 0, 0);
            if (gameObject.GetComponent<Transform>().position.x >= posicionInicial.x + dist_lateral)
            {
                paso = 2;
            }

        }


        if (posicionInicial.x - dist_lateral < gameObject.GetComponent<Transform>().position.x && paso==2)
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
}
