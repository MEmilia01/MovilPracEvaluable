using UnityEngine;

public class SpawnEne : MonoBehaviour
{
    private int randomenemy;


    void Start()
    {
        randomenemy = Random.Range(0, 1);
        //si es 0 es una bomba y si 1 es comida
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
