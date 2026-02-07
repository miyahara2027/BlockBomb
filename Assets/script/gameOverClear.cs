using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverClear : MonoBehaviour
{
    // Start is called before the first frame update

    private Text gameMassage;
    void Start()
    {
        gameMassage = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.instance.isClear){
            gameMassage.text = "Game Clear";
            gameMassage.color = Color.yellow;
        } else if(gameController.instance.isGameOver){
            gameMassage.text = "Game Over";
            gameMassage.color = Color.red;
        }
    }
}
