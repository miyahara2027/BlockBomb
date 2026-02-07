using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    private float fallTime = 10f;
    private float previousTime;
    private Animator animator;
    private SpriteRenderer sr ;

    public bool isExplosion = false;
    public string bombTag;
    public bool isAwake = false;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        sr = this.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if(!gameController.instance.isGameOver && !gameController.instance.isClear){   
            if(!isExplosion){
                Movement();
            } else{
                sr.sortingLayerName = "Explosion";
                if(isExplosionEnd()){
                    DestroyArray();
                }
            }
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
                isExplosion = true;
                if(this.tag == "red"){
                    animator.Play("redBombExplosion");
                }
                if(this.tag == "blue"){
                    animator.Play("blueBombExplosion");
                }
                if(this.tag == "green"){
                    animator.Play("greenBombExplosion");
                }
                if(this.tag == "yellow"){
                    animator.Play("yellowBombExplosion");
                }
            }
        }
        previousTime += Time.deltaTime;
    }

    private bool isInArea(){
        int posX = Mathf.RoundToInt(this.transform.position.x);
        int posY = Mathf.RoundToInt(this.transform.position.y);
        if(posX >= 10 || posX <= -1 || posY <= -1 || posY >= 16){
            return false;
        }
        if(gameController.instance.blockList[posX,posY] != null){
            return false;
        }
        return true;
    }

    private void DestroyArray(){
        int posX = Mathf.RoundToInt(this.transform.position.x);
        int posY = Mathf.RoundToInt(this.transform.position.y);
        if(posX-1 >= 0 && posY-1 >= 0) checkBlock(posX-1,posY-1);
        if(posY-1 >= 0) checkBlock(posX,posY-1);
        if(posX+1 <= 9 && posY-1 >=0) checkBlock(posX+1,posY-1);
        if(posX-1 >= 0) checkBlock(posX-1,posY);
        if(posX+1 <= 9) checkBlock(posX+1,posY);
        if(posX-1 >= 0 && posY+1 <= 15) checkBlock(posX-1,posY+1);
        if(posY+1 <= 15) checkBlock(posX,posY+1);
        if(posX+1 <= 9 && posY+1 <= 15) checkBlock(posX+1,posY+1);
        gameController.instance.isDestroying = true;
        gameController.instance.score += gameController.instance.getPoint;
        gameController.instance.getPoint += 10;
        
        Destroy(this.gameObject);
    }

    private void checkBlock(int x, int y){
        if(gameController.instance.blockList[x,y] != null && gameController.instance.blockList[x,y].tag == this.tag){
            gameController.instance.blockList[x,y].GetComponent<oneBlock>().DesroyBlock();
        }
    }

    private bool isExplosionEnd(){
        if(isExplosion && animator != null){
            AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
            if(currentState.normalizedTime >= 1){
                return true;
            }
        }
        return false;
    }

}
