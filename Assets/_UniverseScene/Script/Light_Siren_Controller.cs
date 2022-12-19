using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Siren_Controller : MonoBehaviour
{
    public GameObject Light;

    void Start()
    {
        Light.GetComponent<Light>().enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        Light.GetComponent<Light>().enabled = true;
        Light.GetComponent<Light>().color = new Color(0f, 1f, 1f, 1f);

    }

    private void OnTriggerExit(Collider other)
    {
        Light.GetComponent<Light>().enabled = false;
    }
}
