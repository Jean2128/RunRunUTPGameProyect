using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour
{
    [Header("Botones del Menu Principal")]
    public GameObject titulo;
    public GameObject botonJugar;
    public GameObject botonOpciones;
    public GameObject botonAyuda;
    public GameObject botonCreditos;
    public GameObject botonSalir;

    [Header("Paneles")]
    public GameObject panelOpciones;
    public GameObject panelAyuda;
    public GameObject panelCreditos;

    [Header("Opciones - Audio")]
    public Slider sliderMusica;
    public Slider sliderSonido;
    public Toggle toggleMusica;
    public Toggle toggleSonido;

    [Header("Transicion")]
    public Animator transicionAnimator;
    public float tiempoTransicion = 1f;

    [Header("Escenas")]
    public string nombreEscenaJuego = "SampleScene";

    private void Start()
    {
        CerrarTodosLosPaneles();

        if (sliderMusica != null)
            sliderMusica.value = PlayerPrefs.GetFloat("VolumenMusica", 1f);
        if (sliderSonido != null)
            sliderSonido.value = PlayerPrefs.GetFloat("VolumenSonido", 1f);
        if (toggleMusica != null)
            toggleMusica.isOn = PlayerPrefs.GetInt("MusicaActiva", 1) == 1;
        if (toggleSonido != null)
            toggleSonido.isOn = PlayerPrefs.GetInt("SonidoActivo", 1) == 1;
    }

    public void BotonJugar()
    {
        StartCoroutine(CargarEscenaConTransicion(nombreEscenaJuego));
    }

    public void BotonOpciones()
    {
        CerrarTodosLosPaneles();
        MostrarBotonesMenu(false);
        panelOpciones.SetActive(true);
    }

    public void BotonAyuda()
    {
        CerrarTodosLosPaneles();
        MostrarBotonesMenu(false);
        panelAyuda.SetActive(true);
    }

    public void BotonCreditos()
    {
        CerrarTodosLosPaneles();
        MostrarBotonesMenu(false);
        panelCreditos.SetActive(true);
    }

    public void BotonSalir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    public void BotonVolver()
    {
        CerrarTodosLosPaneles();
        MostrarBotonesMenu(true);
    }

    public void CambiarVolumenMusica(float valor)
    {
        PlayerPrefs.SetFloat("VolumenMusica", valor);
    }

    public void CambiarVolumenSonido(float valor)
    {
        PlayerPrefs.SetFloat("VolumenSonido", valor);
    }

    public void ToggleMusica(bool activo)
    {
        PlayerPrefs.SetInt("MusicaActiva", activo ? 1 : 0);
    }

    public void ToggleSonido(bool activo)
    {
        PlayerPrefs.SetInt("SonidoActivo", activo ? 1 : 0);
    }

    void CerrarTodosLosPaneles()
    {
        if (panelOpciones != null) panelOpciones.SetActive(false);
        if (panelAyuda != null)    panelAyuda.SetActive(false);
        if (panelCreditos != null) panelCreditos.SetActive(false);
    }

    void MostrarBotonesMenu(bool mostrar)
    {
        if (titulo != null) titulo.SetActive(mostrar);
        if (botonJugar != null)    botonJugar.SetActive(mostrar);
        if (botonOpciones != null) botonOpciones.SetActive(mostrar);
        if (botonAyuda != null)    botonAyuda.SetActive(mostrar);
        if (botonCreditos != null) botonCreditos.SetActive(mostrar);
        if (botonSalir != null)    botonSalir.SetActive(mostrar);
    }

    IEnumerator CargarEscenaConTransicion(string nombreEscena)
    {
        if (transicionAnimator != null)
            transicionAnimator.SetTrigger("Iniciar");

        yield return new WaitForSeconds(tiempoTransicion);
        SceneManager.LoadScene(nombreEscena);
    }
}