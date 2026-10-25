using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [Header("Menus necesarios")]
    [SerializeField] GameObject menuhub;
    [SerializeField] GameObject menupausa;
    [SerializeField] GameObject menumensaje;
    [SerializeField] GameObject menuvictoria;
    [SerializeField] GameObject menudatos;

    [Header("Extras de texto o gameobjects")]
    public TextMeshProUGUI puntostexto;
    public TextMeshProUGUI mentexto;
    public TextMeshProUGUI version;
    public TextMeshProUGUI meta;
    [SerializeField] GameObject btoncont;
    private bool aplicacionEnSegundoPlano;

    void Start()
    {
        AbrirPausa();
    }


    private void SeleccionarBoton(GameObject boton)
    {
        //hay unos problemas en el pausa, asi que lo hago mejor con eventos
        if (boton != null && boton.activeInHierarchy)
        {
            EventSystem.current.SetSelectedGameObject(boton);
            Debug.Log("este es el boton que esta siendo obtenido: " + boton);
        }
    }

    public void ActualiMensaje()
    {
        if (aplicacionEnSegundoPlano) { mentexto.text = "   Has dejado la aplicacion en segundo plano, por favor vuelve TnT"; }
        else { mentexto.text = "   Holi"; return; }
    }
    public void Reinicio() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
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
        ActualiMensaje();

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

        version.text = " Version del proyecto:  2.50";

#if UNITY_EDITOR
        version.text = " Version del proyecto:  " + PlayerSettings.bundleVersion;
#endif
    }

//interfaz
#if UNITY_STANDALONE
    private void OnApplicationFocus(bool tieneFoco)
    {
        if (!tieneFoco)
        {
            aplicacionEnSegundoPlano = true;
            AbrirMensaje();
        }
        else
        {
            aplicacionEnSegundoPlano = false;
        }
    }
#elif UNITY_ANDROID
    private void OnApplicationPause(bool pausada)
    {
        aplicacionEnSegundoPlano = pausada;

        if (pausada)
        {
            AbrirMensaje();
        }
        else { return; }
    }
#endif
}
