using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Agrega este using para acceder a TextMeshProUGUI

public class GameManager : MonoBehaviour
{
    public static int vidas = 3;
    public static int puntos = 0; // Points variable declared once
    public static int muertes = 0;
    public static bool estoyMuerto = false;

    GameObject VidasText;
    
    // Start is called before the first frame update
    void Start()
    {
        VidasText = GameObject.Find("VidasText");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Puntos: " + puntos);
        Debug.Log("Deads: " + muertes);

        // Asegúrate de que el GameObject VidasText tenga el componente TextMeshProUGUI
        if (VidasText != null)
        {
            // Accede al componente TextMeshProUGUI y actualiza el texto
            VidasText.GetComponent<TextMeshProUGUI>().text = vidas.ToString();
        }
        else
        {
            Debug.LogWarning("No se encontró el objeto VidasText.");
        }
    }
}
