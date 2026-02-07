using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextSecond : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sr0;
    private SpriteRenderer sr1;

    void Start()
    {
        Transform child0 = transform.GetChild(0);
        Transform child1 = transform.GetChild(1);

        sr0 = child0.GetComponent<SpriteRenderer>();
        sr1 = child1.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.instance.second.GetComponent<SpriteRenderer>() == null){
            sr0.sprite = gameController.instance.second.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            sr1.sprite = gameController.instance.second.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
        } else {
            sr0.sprite = gameController.instance.second.GetComponent<SpriteRenderer>().sprite;
            sr1.sprite = null;
        }
    }
}
