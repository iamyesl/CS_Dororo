using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Siren : MonoBehaviour
{
    public AudioSource SirenSound;

    
    void Start()
    {
        SirenSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            SirenSound.Play(); //������ �����ϴ� �κ�
        }
    }

}
