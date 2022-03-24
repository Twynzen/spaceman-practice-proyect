using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /// <summary>
        /// Sent when another object enters a trigger collider attached to this
        /// object (2D physics only).
        /// </summary>
        /// <param name="other">The other Collider2D involved in this collision.</param>
        
    }
    void OnTriggerEnter2D(Collider2D collision)
        {
            //se llama la etiqueta de identificación del player
            //para condicionar de que si cae este en la zona debe morir
            if(collision.tag == "Player"){
                //llamamos la clase del player y ejecutamos su función de morir
                PlayerControl controller = collision.GetComponent<PlayerControl>();
                controller.Die();
            }
        }
}
