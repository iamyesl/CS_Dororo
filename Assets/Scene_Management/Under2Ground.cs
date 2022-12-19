using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Under2Ground : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("GroundScene");
    }
}
