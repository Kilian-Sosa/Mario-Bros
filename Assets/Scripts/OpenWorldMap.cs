using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenWorldMap : MonoBehaviour {

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) 
            if (SceneManager.loadedSceneCount == 1) 
                SceneManager.LoadScene("WorldMap", LoadSceneMode.Additive);
    }
}
