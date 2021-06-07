using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Creditos : MonoBehaviour
{
    public Text creditos;
    public Text puntuacion;
    // Start is called before the first frame update
    void Start()
    {
        puntuacion.text = "Puntuación  :  " +GameController.Puntuacion;
        StartCoroutine("Esperar");
    }

    // Update is called once per frame
    void Update()
    {
        
            creditos.transform.Translate(0, 50 * Time.deltaTime, 0);
        
        
    }

    public IEnumerator Esperar()
    {
        yield return new WaitForSeconds(20f);

      
            SceneManager.LoadScene("Inicio");
        
        


    }
}
