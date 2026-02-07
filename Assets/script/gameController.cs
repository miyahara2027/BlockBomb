using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public static gameController instance {get; private set;}
    public Transform[,] blockList = new Transform[10,16];
    public bool isDestroying = false;
    private bool isNewBlock = false;

    public GameObject first;
    public GameObject second;
    public GameObject third;

    public bool isGameOver = false;
    public bool isClear = false;
    public int score = 0;
    public int getPoint = 10;
    public int blockCount = 10;

    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isDestroying){
            foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject))){
                if(obj.tag == "red" || obj.tag == "blue" || obj.tag == "green" || obj.tag == "yellow"){
                    if(obj.GetComponent<oneBlock>().isExplosion){
                        isDestroying = true;
                        isNewBlock = false;
                        break;
                    }
                }
                isDestroying = false;
                isNewBlock = true;
            }
        }
        if(isNewBlock){
            FindObjectOfType<spawn>().newBlock();
            isNewBlock = false;
            getPoint = 10;
        }
        if(blockList[4,15] != null || blockList[5,15] != null){
            isGameOver = true;
        }
        if(blockCount <= 0){
            isClear = true;
        }
    }
}
