using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioScript : MonoBehaviour
{

    GameObject panelSettings;

    // Start is called before the first frame update
    void Start()
    {
        panelSettings = GameObject.Find("PanelSettings");
        panelSettings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene("1Escena");
    }

    public void ExitGame(){
        Debug.Log("exit");
        Application.Quit();
    }

    public void MostrarSettings(){
        panelSettings.SetActive(true);
    }

    public void OcultarSettings(){
        panelSettings.SetActive(false);
    }
}
