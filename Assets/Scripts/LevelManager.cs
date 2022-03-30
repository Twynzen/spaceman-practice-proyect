using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager sharedInstance;
    public List<LevelBlock> allTheLevelBlocks;
    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>();
    public Transform levelStartPosition;

    void Awake(){
        if(sharedInstance == null){
            sharedInstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddLevelBlock(){
        //generamos un número aleatorio dentro de las posiciones disponibles
        //Esto es una generación equiprobable de un rango de bloques disponibles
        int randomIdx = Random.Range(0, allTheLevelBlocks.Count);

        LevelBlock block;

        //Aqui colocaremos una varibale donde queremos colocar el bloque
        Vector3 spawnPosition = Vector3.zero;

        //El bloque #0 debe instanciarse siempre por primera vez.
        //Si no hay bloques en escena
        if(currentLevelBlocks.Count == 0){
            //Instanciamos el primer bloque
            block = Instantiate(allTheLevelBlocks[0]);
            spawnPosition = levelStartPosition.position;
            
            Debug.Log(spawnPosition);

        }
        else
        {
            //Instanciamos los bloques de forma aleatoria
            block = Instantiate(allTheLevelBlocks[randomIdx]);
            //colocamos el bloque al final del últiumo bloque generado
            spawnPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].endPoint.position;
        }
        //El padre del bloque actual es el level manager
        block.transform.SetParent(this.transform,false);

        Vector3 correction = new Vector3(spawnPosition.x-block.startPoint.position.x,
                                         spawnPosition.y-block.startPoint.position.y,0);
            block.transform.position = correction;
            currentLevelBlocks.Add(block);
    }
    public void RemoveLevelBlock(){

    }
    public void RemoveAllLevelBlocks(){

    }   
    public void GenerateInitialBlocks(){
        for (int i=0; i<10; i++ ){
            AddLevelBlock();
        }
    }
}
