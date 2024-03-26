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

        transform.position = new Vector3(-9.3f, 3.7f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        float miDeltaTime = Time.deltaTime;

        //CHARACTER MOVEMENT
        float movTeclas = Input.GetAxis("Horizontal"); //(a -1f - d 1f)
    //  float movTeclasY = Input.GetAxis("Vertical"); //(a -1f - d 1f)

        rb.velocity =  new Vector2(movTeclas*multiplicador, rb.velocity.y);


        // Flip <-- LEFT
         if(movTeclas < 0){
                        this.GetComponent<SpriteRenderer>().flipX = true;         
         }else if(movTeclas > 0){
                      this.GetComponent<SpriteRenderer>().flipX = false;         
         }


        //JUMP JUMP!

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
