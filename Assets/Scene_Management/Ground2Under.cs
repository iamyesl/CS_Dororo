using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ground2Under : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("UnderwaterScene");
    }
}
