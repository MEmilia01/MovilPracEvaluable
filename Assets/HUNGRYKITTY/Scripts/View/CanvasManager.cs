using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject menuhub;
    [SerializeField] GameObject menupausa;
    [SerializeField] GameObject menumensaje;
    [SerializeField] GameObject menuvictoria;
    [SerializeField] GameObject menudatos;

    public TextMeshProUGUI puntostexto;
    public TextMeshProUGUI mentexto;
    public TextMeshProUGUI version;

    [SerializeField] GameObject btoncont;

    void Start()
    {
        //Time.timeScale = 0f;
        //AbrirDatos();
    }

    private void SeleccionarBoton(GameObject boton)
    {
        if (boton != null && boton.activeInHierarchy)
        {
            EventSystem.current.SetSelectedGameObject(boton);
            Debug.Log("este es el boton que esta siendo obtenido: " + boton);
        }
    }
    public void Reinicio() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); AbrirHub(); }
    public void Salir() { Application.Quit(); }



    public void AbrirHub()
    {
        Time.timeScale = 1.0f;

        menuhub.SetActive(true);
        menupausa.SetActive(false);
        menumensaje.SetActive(false);
        menuvictoria.SetActive(false);
        menudatos.SetActive(false);
    }
    public void AbrirPausa()
    {
        menuhub.SetActive(false);
        menupausa.SetActive(true);
        menumensaje.SetActive(false);
        menuvictoria.SetActive(false);
        menudatos.SetActive(false);
        
        Time.timeScale = 0f;
        SeleccionarBoton(btoncont);
    }
    public void AbrirMensaje()
    {
        menuhub.SetActive(false);
        menupausa.SetActive(false);
        menumensaje.SetActive(true);
        menuvictoria.SetActive(false);
        menudatos.SetActive(false);
    }
    public void AbrirVitoria()
    {
        menuhub.SetActive(false);
        menupausa.SetActive(false);
        menumensaje.SetActive(false);
        menuvictoria.SetActive(true);
        menudatos.SetActive(false);

        Time.timeScale = 0f;
    }
    public void AbrirDatos()
    {
        menuhub.SetActive(false);
        menupausa.SetActive(false);
        menumensaje.SetActive(false);
        menuvictoria.SetActive(false);
        menudatos.SetActive(true);

        version.text = " Version del proyecto:  " + PlayerSettings.bundleVersion;
    }
}
