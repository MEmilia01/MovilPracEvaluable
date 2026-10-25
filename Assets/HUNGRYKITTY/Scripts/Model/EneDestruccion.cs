using UnityEngine;

public class EneDestruccion : MonoBehaviour
{
    [Header("Forma de ganar puntuacion")]
    [SerializeField] Puntuacion holderpuntuacion;
    private void Start()
    {
        holderpuntuacion = GetComponentInParent<Puntuacion>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int sum = 1;

        if (collision.tag == "Player")
        {
            Debug.Log("Entra al toque");
            holderpuntuacion.SetPuntos = holderpuntuacion.GetPuntos + sum;
            Destroy(this.gameObject);
        }
    }
}
