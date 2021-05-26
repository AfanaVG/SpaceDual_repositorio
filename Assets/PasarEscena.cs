using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarEscena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Esperar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public IEnumerator Esperar()
    {
        yield return new WaitForSeconds(9.5f);
        SceneManager.LoadScene("SampleScene");
    }
}
