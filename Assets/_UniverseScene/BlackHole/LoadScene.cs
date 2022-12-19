using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public Object SceneToLoad;
    Scene CurrentScene;
    // Start is called before the first frame update
    void Start()
    {
        CurrentScene = gameObject.scene;
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        SceneManager.LoadScene(SceneToLoad.name);
    }
}
