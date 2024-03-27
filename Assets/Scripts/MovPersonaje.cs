using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{

    public float multiplicador = 5f;
    public float multiplicadorSalto = 5f;

    private bool puedoSaltar = true;
    private Rigidbody2D rb;
    private Animator animatorController;
     GameObject respawn;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        animatorController = this.GetComponent<Animator>();

        respawn = GameObject.Find("Respawn");
        transform.position = respawn.transform.position;

        Respawnear();
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.estoyMuerto) return;

        float miDeltaTime = Time.deltaTime;

        //CHARACTER MOVEMENT
        float movTeclas = Input.GetAxis("Horizontal"); //(a -1f - d 1f)
    //  float movTeclasY = Input.GetAxis("Vertical"); //(a -1f - d 1f)

        rb.velocity =  new Vector2(movTeclas*multiplicador, rb.velocity.y);


        // LEFT
         if(movTeclas < 0){
            this.GetComponent<SpriteRenderer>().flipX = true;  
         }else if(movTeclas > 0){
        // RIGHT
            this.GetComponent<SpriteRenderer>().flipX = false;
         }

         //WALKING ANIMATION 
        if(movTeclas != 0){
            animatorController.SetBool("activaCamina", true);
        }else{
            animatorController.SetBool("activaCamina", false);
        }















        //JUMP JUMP!

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f);
        Debug.DrawRay(transform.position, Vector2.down, Color.magenta);

        if(hit){
            puedoSaltar = true;
            // Debug.Log(hit.collider.name);
        }else{
            puedoSaltar = false;
        }
 
        if(Input.GetKeyDown(KeyCode.Space) && puedoSaltar ){
            rb.AddForce(
                new Vector2(0,multiplicadorSalto),
                ForceMode2D.Impulse
          );
        }   

        //COMPROBAR SI HE SALIDO DE LA PANTALLA POR ABAJO 

        if(transform.position.y <= -4){
            Respawnear();
        }

        // 0 VIDAS 

            if(GameManager.vidas <= 0)
            {
                GameManager.estoyMuerto = true;
            }



    }
    

   public void Respawnear(){

    Debug.Log("vidas" +GameManager.vidas);
    GameManager.vidas = GameManager.vidas - 1 ;
    Debug.Log("vidas" +GameManager.vidas);


    transform.position = respawn.transform.position;
    }

    



}
