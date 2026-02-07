using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    // Start is called before the first frame update

    private Text scoreText;
    


    void Start()
    {
        scoreText = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score " + gameController.instance.score.ToString("d4");
    }
}
