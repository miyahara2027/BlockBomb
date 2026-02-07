using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    private float fallTime = 5f;
    private float previousTime;

    public string blockTag;
    


    void Start()
    {
        
    }

    
    void Update()
    {
       if(!gameController.instance.isGameOver && !gameController.instance.isClear){
            Movement();
       }
    }

    private void Movement(){
        if(Input.GetKeyDown(KeyCode.D)){
            transform.position += new Vector3(1,0,0);
            if(!isInArea()){
                transform.position += new Vector3(-1,0,0);
            }
        } else if(Input.GetKeyDown(KeyCode.A)){
            transform.position += new Vector3(-1,0,0);
            if(!isInArea()){
                transform.position += new Vector3(1,0,0);
            }
        } else if(Input.GetKeyDown(KeyCode.S) || previousTime >= fallTime){
            transform.position += new Vector3(0,-1,0);
            previousTime = 0;
            if(!isInArea()){
                transform.position += new Vector3(0, 1, 0);
                this.enabled = false;
                FindObjectOfType<spawn>().newBlock();
                addArry();
                foreach(Transform children in transform){
                    children.GetComponent<oneBlock>().isAwake = true;
                }
            }
        } else if(Input.GetKeyDown(KeyCode.W)){
            transform.Rotate(0,0,90);
            if(!isInArea()){
                transform.Rotate(0,0,-90);
            }
        }
        previousTime += Time.deltaTime;
    }

    private bool isInArea(){
        foreach(Transform children in transform){
            int posX = Mathf.RoundToInt(children.transform.position.x);
            int posY = Mathf.RoundToInt(children.transform.position.y);
            if(posX >= 10 || posX <= -1 || posY <= -1 || posY >= 16){
                return false;
            }
            if(gameController.instance.blockList[posX,posY] != null){
                return false;
            }
        }
        return true;
    }

    private void addArry(){
        foreach(Transform children in transform){
            int posX = Mathf.RoundToInt(children.transform.position.x);
            int posY = Mathf.RoundToInt(children.transform.position.y);
            gameController.instance.blockList[posX,posY] = children;
            foreach(var s in gameController.instance.blockList)
            {
                if(s != null){
                    Debug.Log(s);
                }
            }
        }
    }

}
