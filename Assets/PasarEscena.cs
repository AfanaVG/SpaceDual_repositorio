using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PasarEscena : MonoBehaviour
{
    // Start is called before the first frame update

    public static int nivel = 0;

    public Text TextNombre;


    private void Awake()
    {

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        nivel++;
        TextNombre.text = "NIVEL  -  " + nivel;


        

        StartCoroutine("Esperar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public IEnumerator Esperar()
    {
        yield return new WaitForSeconds(9.5f);

        if (nivel == 1)
        {
            SceneManager.LoadScene("Nivel2");
        }else if(nivel == 2)
        {
            SceneManager.LoadScene("Nivel3");
        }
        else if (nivel == 3)
        {
            SceneManager.LoadScene("Nivel1");
        }

    }
}
