using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject ScrollView;
    public GameObject Text;
    private bool isMenuActive = false;


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
        /*if (Input.GetKeyDown(KeyCode.U) && Text.Inactive){
            Text.SetActive(true);
            ScrollView.SetActive(true);
        }*/

        if (Input.GetKeyDown(KeyCode.U)){
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

        /*if (Input.GetKeyDown(KeyCode.H) && lightsMode == LightsMode.Inactive){
            lightsMode = LightsMode.Active;
            }
     else if (Input.GetKeyDown(KeyCode.H) && lightsMode == LightsMode.Active){
            lightsMode = LightsMode.Inactive;}*/
    }
}
