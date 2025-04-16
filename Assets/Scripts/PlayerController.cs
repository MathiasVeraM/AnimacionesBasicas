using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rbMV;
    private Animator animatorMV;
    private Vector3 originalScaleMV;
    private float moveInputMV;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbMV = GetComponent<Rigidbody2D>();
        animatorMV = GetComponent<Animator>();
        originalScaleMV = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento horizontal
        moveInputMV = Input.GetAxisRaw("Horizontal");

        // Animación: está caminando si moveInput no es 0
        bool isWalking = moveInputMV != 0;
        animatorMV.SetBool("isWalking", isWalking);

        if (moveInputMV > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(originalScaleMV.x), originalScaleMV.y, originalScaleMV.z);
        }
        else if (moveInputMV < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(originalScaleMV.x), originalScaleMV.y, originalScaleMV.z);
        }
    }
    void FixedUpdate()
    {
        // Aplicar movimiento
        rbMV.linearVelocity = new Vector2(moveInputMV * speed, rbMV.linearVelocityY);
    }
}
