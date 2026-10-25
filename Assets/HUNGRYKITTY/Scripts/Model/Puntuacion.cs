using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    [Header("Holder de la puntuacion")]
    private int puntos = 0;
    //public int meta = 20;

    public int GetPuntos { get => puntos; }
    public int SetPuntos { set => puntos = value; }

//Esto se utilizara mas como una forma conceptual
//ya que en si no su puede aplicar a una lit
#if UNITY_STANDALONE

    //Aca se guardarian en una lista los puntuajes mas grandes
    //para tenerlos como mejores "puntuaciones"

#elif UNITY_ANDROID

    //Aca se mandarian esa lista a los google play games 
    //para que sea compartida entre los usuarios y vean su mayor puntuacion

#endif

}
