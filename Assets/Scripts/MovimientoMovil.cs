using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMovil : MonoBehaviour
{

    public string direccion;
    private bool pulsado = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (pulsado)
        {
            if (direccion.Equals("ARRIBA"))
            {
                DualController.dualScript.MovArriba();
            }

            if (direccion.Equals("ABAJO"))
            {
                DualController.dualScript.MovAbajo();
            }

            if (direccion.Equals("DERECHA"))
            {
                DualController.dualScript.MovDerecha();
            }

            if (direccion.Equals("IZQUIERDA"))
            {
                DualController.dualScript.MovIzquierda();
            }

        }
        else if (!pulsado)
        {

        }
        
    }


    public void pulsadoOn()
    {
        pulsado = true;
    }

    public void pulsadoOff()
    {
        pulsado = false;
    }
}
