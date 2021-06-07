using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject fondo;
    public float velocidad;
    public float tamano;
    public float inicioBucle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MueveFondos();
    }

    void MueveFondos()
    {


        if (Math.Abs(fondo.transform.localPosition.y) > tamano)
        {
            //fondo.transform.localPosition = new Vector3(0.0f, 90.2f, fondo.transform.position.z);

            fondo.transform.localPosition = new Vector3(0.0f, inicioBucle, fondo.transform.position.z);
        }
        else
        {
            float offset = Time.deltaTime * -velocidad;
            fondo.transform.localPosition += new Vector3(0.0f,offset, 0.0f);
        }

    }
}
