using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] float xMin, xMax;

    private void Start() {
        AudioManager.instance.PlayMusic("MainTheme");    
    }

    void Update() {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, xMin, xMax), 
            transform.position.y, transform.position.z);
    }
}