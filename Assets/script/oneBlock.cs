using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneBlock : MonoBehaviour
{
    // Start is called before the first frame update
   
    public bool isAwake = false;
    public bool isExplosion = false;

    private Animator animator;
    private SpriteRenderer sr ;


    void Start()
    {
        animator = this.GetComponent<Animator>();
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAwake){


            int posX = Mathf.RoundToInt(this.transform.position.x);
            int posY = Mathf.RoundToInt(this.transform.position.y);
            if(posY >= 1 && posY <= 15 && gameController.instance.blockList[posX,posY-1] == null){
                gameController.instance.blockList[posX,posY] = null;
                gameController.instance.blockList[posX,posY-1] = this.transform;
                transform.position += new Vector3(0,-1,0);
            }
        }
        if(isExplosion){
            sr.sortingLayerName = "Explosion";
            if(isExplosionEnd()){
                DestroyArray();
            }
        }
    }

    public void DesroyBlock(){
        isExplosion = true;
        if(this.tag == "red"){
            animator.Play("redBlockExplosion");
        }
        if(this.tag == "blue"){
            animator.Play("blueBlockExplosion");
        }
        if(this.tag == "green"){
            animator.Play("greenBlockExplosion");
        }
        if(this.tag == "yellow"){
            animator.Play("yellowBlockExplosion");
        }
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
        
        gameController.instance.blockList[posX,posY] = null;
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
