using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class last : MonoBehaviour
{
    // Start is called before the first frame update
    private Text lastText;

    void Start()
    {
        lastText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lastText.text = "Last\n" + gameController.instance.blockCount;
    }
}
