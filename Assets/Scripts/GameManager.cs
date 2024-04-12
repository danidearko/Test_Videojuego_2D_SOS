using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Correctamente agregado para usar TextMeshPro

public class GameManager : MonoBehaviour
{
    public static int vidas = 3;
    public static int puntos = 0; // Variable de puntos
    public static int muertes = 0; // Variable de muertes
    public static bool estoyMuerto = false; // Estado de "muerto"

    private TextMeshProUGUI vidasText; // Usar el tipo adecuado directamente

    // Start is called before the first frame update
    void Start()
    {
        // Asegúrate de que el objeto VidasText tenga el componente TextMeshProUGUI
        GameObject vidasTextObj = GameObject.Find("VidasText");
        if (vidasTextObj != null)
        {
            vidasText = vidasTextObj.GetComponent<TextMeshProUGUI>();
            if (vidasText == null)
            {
                Debug.LogError("No se encontró el componente TextMeshProUGUI en el objeto VidasText");
            }
        }
        else
        {
            Debug.LogError("No se encontró un objeto llamado 'VidasText' en la escena");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Puntos: " + puntos);
        Debug.Log("Muertes: " + muertes);


        if (vidasText != null)
        {
            vidasText.text = "Vidas: " + vidas; 
        }
    }
}
