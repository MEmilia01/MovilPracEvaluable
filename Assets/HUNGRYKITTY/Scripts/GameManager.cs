using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Puntuacion puntosholder;
    [SerializeField] SpawnEne spaunerenemigos;


    void Start()
    {
        puntosholder = GetComponentInChildren<Puntuacion>();
        spaunerenemigos = GetComponentInChildren<SpawnEne>();
    }

    
    void Update()
    {
        
    }
}
