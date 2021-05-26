using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void IniciarJuego()
    {
        StartCoroutine("Esperar");
    }

    public IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Cortinilla");
    }


}
