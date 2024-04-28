using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    public float velocidad = 5f;
    public float multiplicador = 5f;
    public float multiplicadorSalto = 5f;

    float movTeclas;
    private bool puedoSaltar = true;
    private bool activaSaltoFixed = false;
    public bool miraDerecha = true;
    private Rigidbody2D rb;
    private Animator animatorController;
    GameObject respawn;
    bool soyAzul;

    Animator animacioncaminado;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();
        respawn = GameObject.Find("Respawn");
        transform.position = respawn.transform.position;
        Respawnear();
    }

    void Update()
    {
        if (GameManager.estoyMuerto) return;

        // CHARACTER MOVEMENT
        movTeclas = Input.GetAxis("Horizontal");

        // LEFT & RIGHT
        if (movTeclas < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            miraDerecha = false;
            animatorController.SetBool("activaCamina", false);
        }
        else if (movTeclas > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            miraDerecha = true;
            animatorController.SetBool("activaCamina", true);
        }

        // WALKING ANIMATION
        animatorController.SetBool("activaCamina", movTeclas != 0);

        // JUMP JUMP!
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f);
        Debug.DrawRay(transform.position, Vector2.down, Color.magenta);

        if (hit)
        {
            puedoSaltar = true;
        }
        else
        {
            puedoSaltar = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            activaSaltoFixed = true;
        }

        // COMPROBAR SI HE SALIDO DE LA PANTALLA POR ABAJO
        if (transform.position.y <= -4)
        {
            AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fxDead);
            Respawnear();
        }

        // 0 VIDAS
        if (GameManager.vidas <= 0)
        {
            GameManager.estoyMuerto = true;
        }
    }

    void FixedUpdate()
    {
        if (!activaSaltoFixed)
        {
            rb.velocity = new Vector2(movTeclas * multiplicador, rb.velocity.y);
        }
        else
        {
            rb.AddForce(new Vector2(0, multiplicadorSalto), ForceMode2D.Impulse);
            activaSaltoFixed = false;
        }
    }

    public void Respawnear()
    {
        Debug.Log("vidas" + GameManager.vidas);
        GameManager.vidas -= 1;
        Debug.Log("vidas" + GameManager.vidas);
        transform.position = respawn.transform.position;
    }

    public void CambiarColor()
    {
        if (soyAzul)
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
            soyAzul = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.blue;
            soyAzul = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);

        if (col.gameObject.name == "Tunel")
        {
            // Asegúrate de que la instancia del AudioManager está correctamente referenciada
            AudioManager.Instance.IniciarEfectoTunel();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Tunel")
        {
            // Asegúrate de que la instancia del AudioManager está correctamente referenciada
            AudioManager.Instance.IniciarEfectoDefault();
        }
    }
}
