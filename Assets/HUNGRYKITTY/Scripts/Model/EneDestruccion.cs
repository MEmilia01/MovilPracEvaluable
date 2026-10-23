using UnityEngine;

public class EneDestruccion : MonoBehaviour
{
    public bool bomba;
    [SerializeField] Puntuacion holderpuntuacion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int sum = 1;
        int rest = -1;

        if (collision.tag == "Player")
        {
            if (!bomba) { holderpuntuacion.SetPuntos = holderpuntuacion.GetPuntos + sum; }
            else { holderpuntuacion.SetPuntos = holderpuntuacion.GetPuntos + rest; }
        }
    }
}
