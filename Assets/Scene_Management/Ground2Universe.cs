using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ground2Universe : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("_UniverseScene");
    }
}
