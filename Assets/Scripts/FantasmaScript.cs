using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaScript : MonoBehaviour
{
    Vector3 posicionInicial;
    GameObject personaje;
    public float velocidadFantasma = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        // Encuentra al jugador usando la etiqueta "Player"
        personaje = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula la distancia entre el fantasma y el jugador
        float distancia = Vector3.Distance(transform.position, personaje.transform.position);
        float velocidadFinal = velocidadFantasma * Time.deltaTime;

        if (distancia <= 4.1f) 
        {
            //Debug.DrawLine(transform.position, personaje.transform.position, Color.red, 2.5f);
            transform.position = Vector3.MoveTowards(transform.position, personaje.transform.position, velocidadFinal);
        } 
        else 
        {
            //Debug.DrawLine(transform.position, posicionInicial, Color.white, 2.5f);
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidadFinal);
        }
    }
}
