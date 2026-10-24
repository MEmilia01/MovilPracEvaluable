using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    private int puntos = 0;
    //public int meta = 20;

    public int GetPuntos { get => puntos; }
    public int SetPuntos { set => puntos = value; }

}
