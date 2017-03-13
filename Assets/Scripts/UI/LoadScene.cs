using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LoadScene : MonoBehaviour {
    public string index;

    public void LoadByIndex()
    {
        SceneManager.LoadScene(index);

    }

    void Start()
    {
        Button b = GetComponent<Button>();
        b.onClick.AddListener(LoadByIndex);
        b.GetComponent<Image>().sprite = Resources.Load<Sprite>(index.ToLower());

    }
}
