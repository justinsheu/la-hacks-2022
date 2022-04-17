using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    bool onFloor = true;
    private Rigidbody2D body;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        spriteRenderer.sprite = GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().currentSprite;
        speed = 10 * GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().newSpeed;
        jumpHeight = 10 * GameObject.Find("DarkModeManager").GetComponent<DarkModeController>().newJumpHeight;
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        if (horizontalInput > 0.01F)
            transform.localScale = new Vector3(0.3F, 0.3F, 0.3F);
        else if (horizontalInput < -0.01F)
            transform.localScale =  new Vector3(-0.3F, 0.3F, 0.3F);
        if (Input.GetKey(KeyCode.UpArrow) && onFloor == true)
        {
            body.velocity = new Vector2(body.velocity.x, jumpHeight);
            onFloor = false;
        }
        if (body.position.y < -5)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onFloor = true;
        }
    }
}
