using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseWorldMap : MonoBehaviour {

    void Update() {
        if (Input.GetKeyDown(KeyCode.M))
            if (SceneManager.loadedSceneCount == 2) 
                SceneManager.UnloadSceneAsync("WorldMap");
    }
}
