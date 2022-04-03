using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour { 

    //Seguimos al jugador 
    public Transform target;
    //El offset/compensador sería  la posición donde la camara estaría 
    //compensandose con la posición del  colocando la camara con espacio para ver el escenario
    public Vector3 offset = new Vector3(0.2f, 0.0f, -40f);
    //Tiempo de amortiguación, es apra que la camara tarde un poco en moverse 
    public float dampingTime = 0.3f;
    //La velocidad de movimiento de la cámara
    public Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        //La aplicación intentará ir a 60fps
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera(true);
    }
    //Permitirá resetear la posición de la camara
    public void ResetCameraPosition()
    {
        MoveCamera(false);
    }

    void MoveCamera(bool smooth)
    {
        //el objetivo es seguir al player, pasamos estos parametros al vector3:
        //.1 la posición del objeto a seguir (en este caso player) restando el offset para compensar
        //.2 la posición en y offset 
        //.3 la posición de z offset
        Vector3 destination = new Vector3(
            target.position.x - offset.x,
            offset.y, offset.z);
            
        //si el smooth es true define si el jugador 
        //a muerto y se mueve instantaneamente la camara a la posición de inicio
        //o si se hace un barrido lento acompañando al jugador
        if (smooth)
        {
            //el barrido suavisado va con SmoothDamp recibe de parametros:
            //.1 Posición actual de la camara 
            //.2 El destino que hemos calculado
            //.3 la velocidad se llama con ref (velocidad)
            //.4 el tiempo de amortiguación de la cama en sus barridos
            this.transform.position = Vector3.SmoothDamp(
                this.transform.position,
                destination, ref velocity, dampingTime);
        }
        else
        {// sería el teletransporte de camara inmediato.
            this.transform.position = destination;
        }
    }
}
