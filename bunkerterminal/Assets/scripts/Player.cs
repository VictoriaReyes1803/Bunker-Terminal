using UnityEngine;

public class Player : MonoBehaviour
{
public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;  
    private Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        // SOLO flechas
        if (Input.GetKey(KeyCode.UpArrow))
            moveY = 1f;
        if (Input.GetKey(KeyCode.DownArrow))
            moveY = -1f;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveX = -1f;
        if (Input.GetKey(KeyCode.RightArrow))
            moveX = 1f;

        input = new Vector2(moveX, moveY).normalized;
        float speed = input.sqrMagnitude;
        animator.SetFloat("Speed", speed);

        if (input != Vector2.zero)
        {
            Debug.Log("Input: " + input);
            transform.Translate(input * moveSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = input * moveSpeed;
    }


//     void OnCollisionEnter2D(Collision2D collision)
// {
//     if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
//     {
//         // Aquí sabes que chocaste con una pared
//         // Ejemplo: reproducir sonido, partículas, etc.
//         Debug.Log("Choqué con pared");
//     }
// }

}
