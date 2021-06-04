using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Canvas controles;
    public Canvas inicio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void IniciarJuego()
    {
        StartCoroutine("Esperar");
    }

    public void Controles()
    {
        inicio.enabled = false;
        controles.enabled = true;
    }

    public void Inicio()
    {
        inicio.enabled = true;
        controles.enabled = false;
    }

    public void Creditos()
    {

    }

    public IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Cortinilla");
    }


}
