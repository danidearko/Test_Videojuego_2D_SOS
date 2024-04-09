using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaScript : MonoBehaviour
{


Vector3 posicionInicial;
GameObject personaje;

public float velocidadFantasma = 10.0f;





    // Start is called before the first frame update
    void Start()
    {
         posicionInicial = transform.position;
         //personaje = GameObject.Find("Personaje");
         personaje = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
 void Update()
{
    float distancia = Vector3.Distance(transform.position, personaje.transform.position);
    float velocidadFinal = velocidadFantasma * Time.deltaTime; // Define velocidadFinal fuera para que esté disponible tanto para if como para else.

    if (distancia <= 4.1f) {
        // Si el jugador está cerca, el fantasma lo sigue.
        Debug.DrawLine(transform.position, personaje.transform.position, Color.red, 2.5f);
        transform.position = Vector3.MoveTowards(transform.position, personaje.transform.position, velocidadFinal);
    } else {
        // Si el jugador está lejos, el fantasma regresa a su posición inicial.
        Debug.DrawLine(transform.position, posicionInicial, Color.white, 2.5f); // Cambia personaje.transform.position por posicionInicial.
        transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidadFinal);
    }
}
}