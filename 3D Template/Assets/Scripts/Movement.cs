using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody rb;
    private Vector2 moveAmount;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        rb.linearVelocity = new Vector3 (moveAmount.x, rb.linearVelocity.y, moveAmount.y) * movementSpeed;
    }

    public void HandleMovement(InputAction.CallbackContext ctx)
    {
        moveAmount = ctx.ReadValue<Vector2>();
    }
}
