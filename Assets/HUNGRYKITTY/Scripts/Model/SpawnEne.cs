using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEne : MonoBehaviour
{
    [SerializeField] GameObject comidabuena;
    [SerializeField] private Transform contenedorComidas;

    [SerializeField] Vector2 minRange = new Vector2(-5f, -3f);
    [SerializeField] Vector2 maxRange = new Vector2(5f, 3f);

    public List<GameObject> comidas = new List<GameObject>();


    void Start()
    {

        contenedorComidas = GetComponent<Transform>();
        StartCoroutine(Aparicioncom(20));
    }
    
    IEnumerator Aparicioncom(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            Vector2 posicion = new Vector2(
                Random.Range(minRange.x, maxRange.x),
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
