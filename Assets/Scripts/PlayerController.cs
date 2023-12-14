using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float playerSpeed = 1f;
    [SerializeField] float jumpForce = 1f;

    void Update() {
        float direction = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed * direction, GetComponent<Rigidbody2D>().velocity.y);

        if (direction == 1) 
            GetComponent<SpriteRenderer>().flipX = false;
        if (direction == -1)
            GetComponent<SpriteRenderer>().flipX = true; 
        
        if (Input.GetButtonDown("Fire1"))
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
