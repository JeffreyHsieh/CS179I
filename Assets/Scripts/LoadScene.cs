using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {
    public string index;

    public void LoadByIndex()
    {
        SceneManager.LoadScene(index);
    }
}
