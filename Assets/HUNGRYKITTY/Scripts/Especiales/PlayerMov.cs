using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMov : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions; // arrastra aquí tu asset de Input Actions
    [SerializeField] private float speed = 5f;
    [SerializeField] private float stopDistance = 0.1f;

    private InputAction moveAction;
    private Rigidbody2D rb;
    private Camera cam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        // Action map "Jugador", acción "Move"
        moveAction = inputActions.FindActionMap("Jugador", true).FindAction("Move", true);
    }

    private void OnEnable()
    {
        if (moveAction != null) moveAction.Enable();
    }

    private void OnDisable()
    {
        if (moveAction != null) moveAction.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 screenPos = moveAction.ReadValue<Vector2>();
        Vector2 worldPos = cam.ScreenToWorldPoint(screenPos);

        Vector2 toMouse = worldPos - rb.position;

        if (toMouse.magnitude > stopDistance)
            rb.linearVelocity = toMouse.normalized * speed;
        else
            rb.linearVelocity = Vector2.zero;
    }

}
