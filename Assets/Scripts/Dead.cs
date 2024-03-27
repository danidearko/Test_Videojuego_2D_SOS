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
        // Verificar si la colisión ocurrió con el personaje
        if (col.gameObject == personaje)
        {
            // Activar la lógica de muerte y respawn del personaje
            movPersonaje.Respawnear();
        }
    }
}