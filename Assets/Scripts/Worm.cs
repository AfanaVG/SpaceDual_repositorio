using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    public string color = "";
    public float velocidad = 1f;
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
