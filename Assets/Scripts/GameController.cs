using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{

    public static int Puntuacion = 0;// Puntuacion inicial
    public string NombrePuntuacion = "PUNTOS"; //Cadena que aparecera en pantalla referente a la puntuacion

    public Text TextScore;// Texto que concatenara las variable NombrePuntuacion y Puntuacion

    public static GameController gameController;

    private void Awake()
    {
        gameController = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TextScore != null)
        {
            TextScore.text = NombrePuntuacion+": " + Puntuacion.ToString();
        }
    }
}
