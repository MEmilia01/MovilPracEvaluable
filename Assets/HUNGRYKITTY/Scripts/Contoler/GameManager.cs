using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Puntuacion puntosholder;
    [SerializeField] SpawnEne spaunerenemigos;
    [SerializeField] CanvasManager canvas;

    public int victoria;

    void Start()
    {
        puntosholder = GetComponentInChildren<Puntuacion>();
        spaunerenemigos = GetComponentInChildren<SpawnEne>();
    }

    public void ActualizarPuntuacion()
    {
        canvas.puntostexto.text = "Puntos por comidita: " + puntosholder.GetPuntos.ToString();
        if (puntosholder.GetPuntos == victoria) canvas.AbrirVitoria();
        else return;
    }
    void Update()
    {
        ActualizarPuntuacion();
    }
}
