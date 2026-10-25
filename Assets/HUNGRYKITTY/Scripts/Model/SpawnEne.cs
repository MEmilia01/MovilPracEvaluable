using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEne : MonoBehaviour
{
    [Header("Prefabs y transform necesarios")]
    [SerializeField] GameObject comidabuena;
    [SerializeField] private Transform contenedorComidas;

    [Header("Rango de las apariciones")]
    [SerializeField] Vector2 minRange = new Vector2(-5f, -3f);
    [SerializeField] Vector2 maxRange = new Vector2(5f, 3f);

    [Header("Holder de los objetos")]
    public List<GameObject> comidas = new List<GameObject>();
    public int numvictoria;
    //Camera cam;


    void Start()
    {
        //cam = Camera.main;

        contenedorComidas = GetComponent<Transform>();
        StartCoroutine(Aparicioncom(numvictoria));
    }
    
    IEnumerator Aparicioncom(int cantidad)
    {

        for (int i = 0; i < cantidad; i++)
        {
            Debug.LogError("el numero de la victoria es " + cantidad);

            //float mitadAlto = cam.orthographicSize;
            //float mitadAncho = mitadAlto * cam.aspect;

            Vector2 posicion = new Vector2(
                Random.Range(minRange.x, maxRange.x) ,
                Random.Range(minRange.y, maxRange.y) 
            );
            
            yield return new WaitForSeconds(4f);

            GameObject nuevoobjeto = Instantiate(comidabuena, posicion, Quaternion.identity, contenedorComidas);
            comidas.Add(nuevoobjeto);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 centro = (minRange + maxRange) / 2f;
        Vector3 tamaño = maxRange - minRange;
        Gizmos.DrawWireCube(centro, tamaño);
    }

}
