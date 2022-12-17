using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Right_Controller : MonoBehaviour
{
    public GameObject Pivot;
    private void OnTriggerEnter(Collider other)
    {
        Pivot.GetComponent<Animator>().SetInteger("Right_State", 1);
    }

    private void OnTriggerExit(Collider other)
    {
        Pivot.GetComponent<Animator>().SetInteger("Right_State", 2);
    }
}
