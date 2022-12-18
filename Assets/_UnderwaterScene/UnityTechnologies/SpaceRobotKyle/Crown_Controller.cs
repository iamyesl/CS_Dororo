using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown_Controller : MonoBehaviour
{
    Animator Anim;

    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.speed = 1.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Anim.speed == 0) Anim.speed = 1.0f;
            else Anim.speed = 0.0f;
        }
    }
}
