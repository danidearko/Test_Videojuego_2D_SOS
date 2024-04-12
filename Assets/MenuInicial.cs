using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Asegúrate de que este using esté correctamente referenciado

public class MenuInicial : MonoBehaviour
{
    public void Jugar()
    {
        // Corrige aquí el nombre de SceneManager correctamente
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
