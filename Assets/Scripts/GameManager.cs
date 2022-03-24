using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//posibles estados del juego
public enum GameState{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.menu;

    //Static solo una instancia compartida con todos los demas scripts
    //Para este caso se utiliza el singleton 
    public static GameManager sharedInstance;

    private PlayerControl controller; 

   
     void Awake()
    {
        //la condición valida que no exista otra instancia y no se llame más veces
        if (sharedInstance == null)
        {
            //se define este archivo como que es en si mismo la instancia compartida
            sharedInstance = this;
        }
    }
    

    // Start is called before the first frame update
     void Start()
    {
        //Se busca el tag del player y recuperamos del GameObject el componente PlayerControler
        controller = GameObject.Find("player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    public void Update()
    {
        if ( Input.GetButtonDown("Submit"))
        {

            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            BackToMenu();
        }
        
    }
    //Creamos 3 metodos principales:
    public void StartGame()
    {
        SetGameState(GameState.inGame);
        
    }
    public void GameOver()
    {
            Debug.Log("Cuandooo");

        SetGameState(GameState.gameOver);
        
    }
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
        
    }
    //metodo que permite cambiar el estado del juego
    private void SetGameState(GameState newGameState){
        if (newGameState == GameState.menu)
        {
            //TODO: logica del menu
        }else if (newGameState == GameState.inGame){
            controller.StartGame();
            // TODO: Escena para jugar
        }else if (newGameState == GameState.gameOver){
            //TODO: preparar el juego apra el game over
        }
           this.currentGameState = newGameState;

        
    }


}
