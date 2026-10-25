using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMov : MonoBehaviour
{
    [Header("Datos base del jugador")]
    [SerializeField] private InputActionAsset mapainteraciones; 
    [SerializeField] private float movimiento = 5f;
    [SerializeField] private float espacio = 0.1f;

    [Header("Componentes extras")]
    private InputAction accion;
    private Rigidbody2D rb;
    private Camera cam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        //Con esto encontramos las acciones en especifico
        accion = mapainteraciones.FindActionMap("Jugador", true).FindAction("Move", true);
    }

    private void OnEnable()
    {
        if (accion != null) accion.Enable();
    }

    private void OnDisable()
    {
        if (accion != null) accion.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 screenPos = accion.ReadValue<Vector2>();
        Vector2 worldPos = cam.ScreenToWorldPoint(screenPos);

        Vector2 toMouse = worldPos - rb.position;

        if (toMouse.magnitude > espacio)
            rb.linearVelocity = toMouse.normalized * movimiento;
        else
            rb.linearVelocity = Vector2.zero;
    }

}
