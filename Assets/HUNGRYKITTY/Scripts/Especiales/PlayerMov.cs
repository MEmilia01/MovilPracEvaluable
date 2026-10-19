using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMov : MonoBehaviour
{
    [SerializeField] private Camera camara;
    [SerializeField] private float suavizado = 15f;

    private Vector3 posicionObjetivo;

    private void Start()
    {
        // Si no asignas una cámara en el Inspector, usa la principal
        if (camara == null)
            camara = Camera.main;
    }

    private void Update()
    {
        // Posición del ratón en píxeles
        Vector3 posicionRaton = Input.mousePosition;

        // Convierte píxeles de pantalla a coordenadas del mundo
        posicionObjetivo = camara.ScreenToWorldPoint(posicionRaton);

        // En 2D mantenemos Z en 0 para que el sprite no desaparezca
        posicionObjetivo.z = 0f;

        // Movimiento suave, sin Rigidbody
        transform.position = Vector3.Lerp(
            transform.position,
            posicionObjetivo,
            suavizado * Time.deltaTime
        );
    }

}
