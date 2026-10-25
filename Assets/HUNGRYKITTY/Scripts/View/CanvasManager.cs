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
    public bool enhub;

    void Start()
    {
        enhub = false;
        AbrirPausa();
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
        menuhub.SetActive(true);
        menupausa.SetActive(false);
        menumensaje.SetActive(false);
        menuvictoria.SetActive(false);
        menudatos.SetActive(false);

        Time.timeScale = 1f;
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

        Time.timeScale = 0f;
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

#if UNITY_EDITOR
        version.text = " Version del proyecto:  " + PlayerSettings.bundleVersion;
#endif
    }
}
