using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetupScript : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;

    Camera sceneCamera;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; ++i)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        else
        {
            
            sceneCamera = GameObject.Find("camera_dud").GetComponent<Camera>();

            if(sceneCamera != null)
            {
                sceneCamera.gameObject.GetComponent<Camera>().enabled = false;
                sceneCamera.gameObject.GetComponent<AudioListener>().enabled = false;
            }

            this.transform.GetChild(0).GetComponent<Camera>().enabled = true;
            this.transform.GetChild(0).GetComponent<AudioListener>().enabled = true;
            //Camera.main.gameObject.SetActive(false);
        }
    
    }
    void OnDisable()
    {
        if(sceneCamera != null)
        {
            sceneCamera.gameObject.GetComponent<Camera>().enabled = true;
            sceneCamera.gameObject.GetComponent<AudioListener>().enabled = true;
        }
    }
    
}

