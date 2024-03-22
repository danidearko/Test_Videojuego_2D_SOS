using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{

    public float multiplicador = 5f;
    public float multiplicadorSalto = 5f;

    private bool puedoSaltar = true;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movTeclas = Input.GetAxis("Horizontal"); //(a -1f - d 1f)
    //  float movTeclasY = Input.GetAxis("Vertical"); //(a -1f - d 1f)

        // aproximación 1 
       /* transform.position = new Vector 3 (
            transform.position.x+(movTeclas/100),
            transform.position.y,
            transform.position.z
        )*/

        float miDeltaTime = Time.deltaTime;

        // Debug.Log(Time.deltaTime);

        /*
        transform.Translate(
            movTeclas*(Time.deltaTime*multiplicador),
            0,
            0
        );*/





        //Movimiento Personaje 

        rb.velocity =  new Vector2(movTeclas*multiplicador, rb.velocity.y);


        // Flip <-- LEFT
         if(Input.GetKeyDown(KeyCode.A)){
                       // this.GetComponent<SpriteRenderer>().flipX = true;
                       transform.localScale = new Vector3(-1, 1, 1);
         
         }


        // Flip --> RIGHT
         if(Input.GetKeyDown(KeyCode.D)){
                       // this.GetComponent<SpriteRenderer>().flipX = false;
                       transform.localScale = new Vector3(1, 1, 1);
         
         }

    
        






        //El mejor salto que haya podido existir en la historia del Videojuego contemporáneo 

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f);
        Debug.DrawRay(transform.position, Vector2.down, Color.magenta);

        if(hit){
            puedoSaltar = true;
            Debug.Log(hit.collider.name);
        }else{
            puedoSaltar = false;
        }
 
        if(Input.GetKeyDown(KeyCode.Space) && puedoSaltar ){
            rb.AddForce(
                new Vector2(0,multiplicadorSalto),
                ForceMode2D.Impulse
          );
        // puedoSaltar = false;
        }               
    }

    /*
    void OnCollisionEnter2D(){
         puedoSaltar = true;
         Debug.Log("Colision! OMG");
    }*/




}
