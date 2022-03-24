using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float jumpForce = 6f;
    public const float  runningSpeed = 5f;
    Rigidbody2D playerRigidBody;
    // LayerMask define capas para colicionar
    public LayerMask groundMask;
    Animator animator;
    Vector3 startPosition; 
    //Es util declarar aquí constantes que identifican los boleanso que definen las animaciones
    private const string STATE_ALIVE = "isAlive";
    private const string STATE_ON_THE_GROUND = "isOnTheGround";
    public static PlayerControl sharedInstance;
  // Awake Is the first frame
    void Awake()
    {
          if (sharedInstance == null)
        {
            //se define este archivo como que es en si mismo la instancia compartida
            sharedInstance = this;
        }
        //get component permite llamar componentes de unity
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

        startPosition = this.transform.position;
    }

    public void StartGame(){
                //para llamar una animación e inicializarla con un valor utilizamos 
        //SetBool(configuración del valor boleano)
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);
    //Es ideal colocar un delay/Invoke para que se posicione el personaje correctamente luego de morir
     Invoke("RestartPosition",0.2f);
    }
    void RestartPosition(){
        this.transform.position = startPosition;
        this.playerRigidBody.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //Se puede buscar en la documentación de input manager información de control de teclas 
        // if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
          if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //aquí variamos la condición de animación segun corresponda la función
        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());
        //En este caso Debug es como un console.log permite revisar cosas especificas
        //Aquí se crea una linea en la posición donde estaría el raycast para definir la distancia del suelo
        Debug.DrawRay(this.transform.position, Vector2.down*1.5f, Color.red);
    }
    
    //FixUpdate es un metodo reservado para mantener un flujo independiente a los frames por segundo
    void FixedUpdate()
    {
        //La tremenda chambonada por alguna razon la velocidad de movimiento varía por frame de 2f y 5f, aquí la cambio
        //para que permanezca en 5f
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if (Input.GetAxis("Horizontal") < 0  && Input.GetKey("left"))
            {
            playerRigidBody.velocity = new Vector2(Input.GetAxis("Horizontal")*runningSpeed, playerRigidBody.velocity.y);
            }
            if (Input.GetAxis("Horizontal") > 0 && Input.GetKey("right"))
            {
                playerRigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * runningSpeed, playerRigidBody.velocity.y);


            }


            //detectamos la dirección hacia donde debe caminar el personaje
            if (Input.GetKey("left"))
            {
                playerRigidBody.transform.localScale = new Vector2(-1,1);
            }
            if (Input.GetKey("right"))
            {
                playerRigidBody.transform.localScale  = new Vector2(1,1);
            }

        }else
            { //si no esta la partida corriendo
                playerRigidBody.velocity = new Vector2(0, playerRigidBody.velocity.y);
            }

    }
    void Jump()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame){
            if (IsTouchingTheGround() && GameManager.sharedInstance.currentGameState == GameState.inGame)
            {
                //AddForce recibe 2 parametros
                // 1 => la multiplicación de la dirección (vector2) y el jumpForce (velocidad de salto)
                // 2 => Un ForceMode con su respectivo tipo de fuerza

            playerRigidBody.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
                
            }
        }
    }
    //Pregunta si esta tocando el suelo
    bool IsTouchingTheGround(){
        //Condición de un rayo que permite identificar cuando se toca el suelo, el rayo existe desde el centro del objeto
        //los parametros que necesita Pysics2d.raycast son:
        // 1 => this(para indicar este propio objeto) 
        // transform (para indicar posición rotación y escala) y position para que sea la actual.
        // 2 => la posición hacia donde se traza el rayo
        // 3 => la distancia que tendrá el rayo
        // 4 => la mascara de groundMask creada para definir la capa de suelo
        if (Physics2D.Raycast(this.transform.position,Vector2.down,1.5f,groundMask))
        {
            // GameManager.sharedInstance.currentGameState = GameState.inGame;
            // animator.enabled = true;
            return true;
        }else{
            // animator.enabled = false;
            return false;
        }
    }
    public void Die(){
        this.animator.SetBool(STATE_ALIVE, false);
        GameManager.sharedInstance.GameOver();
    }
}
