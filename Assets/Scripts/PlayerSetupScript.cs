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
            
            sceneCamera = Camera.main;
            if(sceneCamera != null)
            {
                sceneCamera.gameObject.GetComponent<Camera>().enabled = false;
                sceneCamera.gameObject.GetComponent<AudioListener>().enabled = false;

            }
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
