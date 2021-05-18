using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAsync : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //remove data before
        PlayerPrefs.DeleteAll();
        Screen.SetResolution(800, 500, false);
        Invoke("Load", 3);// load very fast, in order to see the beautiful homepage, make a load to delay for 3s >.<
    }

    void Load()  
    {
        SceneManager.LoadSceneAsync(1); // move to 01-level
    }
    
}
