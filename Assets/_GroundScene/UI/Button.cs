using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Panel1;
    void Start()
    {
        Button1 = GameObject.Find("Button");
        Panel1 = GameObject.Find("Panel");
    }

    public void OnClickButton()
    {
        Button1.SetActive(false);
        Panel1.SetActive(false);
    }

    void Update()
    {
        
    }
}
