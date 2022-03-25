using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager sharedInstance;
    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();
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
        int randomIdx = Random.Range(0,allTheLevelBlocks.Count);

        LevelBlock block;

        Vector3 spawnPosition = Vector3.zero;

        //El bloque #0 debe instanciarse siempre por primera vez.
        if(currentLevelBlocks.Count == 0){
            block = Intantiate(allTheLevelBlocks[0]);
            spawnPotition = levelStartPosition.position;
        }else{
            block = Intantiate(allTheLevelBlocks[randomIdx]);
            spawnPosition = currentLevelBlocks[currentLevelBlocks.Count -1].exitPoint.position
        }
    }
    public void RemoveLevelBlock(){

    }
    public void RemoveAllLevelBlocks(){

    }
    public void GenerateInitialBlocks(){
        for (int i=0; i<2; i++ ){
            AddLevelBlock();
        }
    }
}
