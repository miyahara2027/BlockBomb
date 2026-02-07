using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] blocks;
    private GameObject startBlock;
    public Vector2 firstPos;
    public Vector2 secondPos;
    public Vector2 thirdPos;



    void Start()
    {
        startGame();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startGame(){
        startBlock = blocks[Random.Range(0,blocks.Length)];
        Instantiate(startBlock, transform.position, Quaternion.identity);
        gameController.instance.first = blocks[Random.Range(0,blocks.Length)];
        gameController.instance.second = blocks[Random.Range(0,blocks.Length)];
        gameController.instance.third = blocks[Random.Range(0,blocks.Length)];
    }

    public void newBlock(){
        gameController.instance.blockCount += -1;
        if(gameController.instance.blockList[4,15] != null || gameController.instance.blockList[5,15] != null){
            gameController.instance.isGameOver = true;
        }
        Instantiate(gameController.instance.first, transform.position, Quaternion.identity);
        gameController.instance.first = gameController.instance.second;
        gameController.instance.second = gameController.instance.third;
        gameController.instance.third = blocks[Random.Range(0,blocks.Length)];
    }
}
