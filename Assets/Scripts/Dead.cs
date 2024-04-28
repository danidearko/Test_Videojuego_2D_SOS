using UnityEngine;

public class Dead : MonoBehaviour
{
    private MovPersonaje movPersonaje;

    // Referencia al objeto del personaje
    public GameObject personaje;

    // Start is called before the first frame update
    void Start()
    {
        // Obtener el componente MovPersonaje del personaje
        movPersonaje = personaje.GetComponent<MovPersonaje>();
    }

    // Método llamado cuando ocurre una colisión con un trigger
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == personaje)
        {
            AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fxDead);
            movPersonaje.Respawnear();
        }
    }
}