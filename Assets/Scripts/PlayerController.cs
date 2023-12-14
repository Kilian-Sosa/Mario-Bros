using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float playerSpeed = 1f;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] bool isJumping = false;

    [SerializeField] float lineLength = 1f;
    [SerializeField] float offset = 1f;

    void Update() {
        float direction = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed * direction, GetComponent<Rigidbody2D>().velocity.y);

        if (direction == 1) 
            GetComponent<SpriteRenderer>().flipX = false;
        if (direction == -1)
            GetComponent<SpriteRenderer>().flipX = true; 
        
        if (Input.GetButtonDown("Fire1") && !isJumping) {
            AudioManager.instance.PlaySFX("Jump");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        Vector2 origin = new Vector2(transform.position.x, transform.position.y - offset);
        Vector2 target = new Vector2(transform.position.x, transform.position.y - offset - lineLength);
        Debug.DrawLine(origin, target, Color.black);

        RaycastHit2D raycast = Physics2D.Raycast(origin, Vector2.down, lineLength);

        if (raycast.collider == null) isJumping = true;
        else isJumping = false;

        if (raycast.collider == null) SetAnimation("jump");
        else SetAnimation(GetComponent<Rigidbody2D>().velocity.x != 0 ? "run" : "idle");
    }

    void SetAnimation(string name) {
        AnimatorControllerParameter[] parametros = GetComponent<Animator>().parameters;
        foreach (var item in parametros) GetComponent<Animator>().SetBool(item.name, false);
        GetComponent<Animator>().SetBool(name, true);
    }
}
