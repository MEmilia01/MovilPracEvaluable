using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scripts necesarios")]
    [SerializeField] Puntuacion puntosholder;
    [SerializeField] SpawnEne spaunerenemigos;
    [SerializeField] CanvasManager canvas;

    [Header("Meta")]
    public int victoria = 20;

    void Start()
    {
        puntosholder = GetComponentInChildren<Puntuacion>();
        spaunerenemigos = GetComponentInChildren<SpawnEne>();

        victoria = spaunerenemigos.numvictoria;
        canvas.meta.text = "Tu meta es " + victoria;
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
