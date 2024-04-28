using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaScript : MonoBehaviour
{
    AudioSource _audiosource;
    Vector3 posicionInicial;
    GameObject personaje;
    public float velocidadFantasma = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        // Encuentra al jugador usando la etiqueta "Player"
        personaje = GameObject.FindGameObjectWithTag("Player");

        _audiosource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula la distancia entre el fantasma y el jugador
        float distancia = Vector3.Distance(transform.position, personaje.transform.position);
        float velocidadFinal = velocidadFantasma * Time.deltaTime;

        if (distancia <= 4.1f) 
        {
            // Si la distancia es menor o igual a 4.1, mueve el fantasma hacia el jugador
            transform.position = Vector3.MoveTowards(transform.position, personaje.transform.position, velocidadFinal);
            if (!_audiosource.isPlaying)
            {
                _audiosource.Play();
            }
        } 
        else 
        {
            // Si no, mueve el fantasma de regreso a su posición inicial
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidadFinal);

            if((transform.position == posicionInicial) && _audiosource.isPlaying == true){
                            _audiosource.Stop();
                            Debug.Log("STOP RIGHT NOW!");
            }

        }
    }
}

