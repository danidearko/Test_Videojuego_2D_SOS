using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{

    public float multiplicador = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hola Mariano xd");
    }

    // Update is called once per frame
    void Update()
    {
        float movTeclas = Input.GetAxis("Horizontal"); //(a -1f - d 1f)

        // aproximación 1 
       /* transform.position = new Vector 3 (
            transform.position.x+(movTeclas/100),
            transform.position.y,
            transform.position.z
        )*/

        float miDeltaTime = Time.deltaTime;

        Debug.Log(Time.deltaTime);

        transform.Translate(
            movTeclas*(Time.deltaTime*multiplicador),
            0,
            0
        );

        //Debug.Log(Input.GetAxis("Horizontal"));
        
    }
}
