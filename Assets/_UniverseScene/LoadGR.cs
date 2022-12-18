using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGR : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("GroundScene");
    }
}
