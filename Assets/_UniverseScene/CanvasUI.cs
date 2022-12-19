using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject ScrollView;
    public GameObject Text;
    private bool isMenuActive = false;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        ScrollView = GameObject.Find("Scroll View");
        Text = GameObject.Find("Text (TMP)");

        ScrollView.SetActive(false);
        Text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (isMenuActive)
            {
                Text.SetActive(false);
                ScrollView.SetActive(false);
                isMenuActive = false;
            }
            else
            {
                Text.SetActive(true);
                ScrollView.SetActive(true);
                isMenuActive = true;
            }
        }
    }
}
