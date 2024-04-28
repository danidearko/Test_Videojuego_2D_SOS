using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioScript : MonoBehaviour
{
    [SerializeField]
    GameObject panelSettings;

    public void Jugar()
    {
        SceneManager.LoadScene  (SceneManager.GetActiveScene().buildIndex + 1); 
    }

    // Awake is called before Start()
    void Awake()
    {
        // Initialize panelSettings
        if (panelSettings != null)
        {
            panelSettings.SetActive(false);
        }
        else
        {
            Debug.LogError("PanelSettings GameObject not assigned in Inspector!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("1Escena");
    }

    public void ExitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void MostrarSettings()
    {
        AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fxDead);
        if (panelSettings != null)
        {
            panelSettings.SetActive(true);
        }
    }

    public void OcultarSettings()
    {
        if (panelSettings != null)
        {
            panelSettings.SetActive(false);
        }
    }

    public void SuenaBoton()
    {
        AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fxButton);
    }
}
