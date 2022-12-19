using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject ScrollView;
    public GameObject Text;

    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        ScrollView = GameObject.Find("Scroll View");
        Text = GameObject.Find("Text (TMP)");

        ScrollView.SetActive(false);
        Text.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)){
            Text.SetActive(true);
            ScrollView.SetActive(true);

        }
    }
}
