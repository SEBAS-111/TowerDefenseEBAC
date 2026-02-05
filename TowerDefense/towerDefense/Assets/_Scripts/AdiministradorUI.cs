using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdiministradorUI : MonoBehaviour
{
    public GameObject CanvasPrincipal;
    public GameObject MenuGamneOver;
    public GameObject MenuOlaGanada;
    public GameObject MensajeFinOla;
    public SpawnerEnemigo referenciasSpawner;
    public objetivo referenciasObjetivo;
    public AdminJuego referenciaAdminJuego;
    public TMPro.TMP_Text textoRecursos;
    public TMPro.TMP_Text textoOleada;
    public TMPro.TMP_Text textoEnemigos;
    public TMPro.TMP_Text textoJefes;



    private void OnEnable()
    {
        if (referenciasObjetivo != null)
        {
            objetivo obj = referenciasObjetivo.GetComponent<objetivo>();
            if (obj != null)
            {
                obj.EnObjetivoDestruido += MostrarMenuGameover;
            }
        }
        referenciasSpawner.EnOleadaIniciada += ActualizarOla;
        referenciasSpawner.EnOleadaTerminada += MostrarMensajeUltimoEnemigo;
        referenciasSpawner.EnOleadaGanada += MostrarMenuOlaGanada;
        referenciaAdminJuego.EnRecursosModificados += ActualizarRecursos;
    }

    private void OnDisable()
    {
        if (referenciasObjetivo != null)
        {
            objetivo obj = referenciasObjetivo.GetComponent<objetivo>();
            if (obj != null)
            {
                obj.EnObjetivoDestruido -= MostrarMenuGameover;
            }
        }
        referenciasSpawner.EnOleadaIniciada -= ActualizarOla;
        referenciasSpawner.EnOleadaTerminada -= MostrarMensajeUltimoEnemigo;
        referenciasSpawner.EnOleadaGanada -= MostrarMenuOlaGanada;
        referenciaAdminJuego.EnRecursosModificados -= ActualizarRecursos;
    }

    public void ActualizarRecursos()
    {
        textoRecursos.text = $"Recursos: {referenciaAdminJuego.recursos}";
    }

    public void MostrarMensajeUltimoEnemigo()
    {
        MensajeFinOla.SetActive(true);
        Invoke("OcultarMensajeUltimoEnemigo", 3);
    }

    public void OcultarMensajeUltimoEnemigo()
    {
        MensajeFinOla.SetActive(false);
    }


    public void MostrarMenuOlaGanada()
    {
        textoEnemigos.text = $"ENEMIGOS: \t {referenciaAdminJuego.enemigosBaseDerrotados}";
        textoJefes.text = $"JEFES: \t\t {referenciaAdminJuego.enemigosJefeDerrotados}";
        MenuOlaGanada.SetActive(true);
    }

    public void OcultarMenuOlaGanada()
    {
        MenuOlaGanada.SetActive(false);
    }
    public void ActualizarOla()
    {
        textoOleada.text = $"Ola: {referenciasSpawner.oleada}";
        OcultarMenuOlaGanada();
    }

    public void MostrarMenuFinOleada()
    {

    }

    public void OcultarMenuFinOleada()
    {

    }

    public void MostrarMenuGameover()
    {
        MenuGamneOver.SetActive(true);
    }

    public void OcultarMenuGameOver()
    {
        MenuGamneOver.SetActive(false);
    }

    public void Finalizarjuego()
    {
        Application.Quit();
    }

    public void CargarMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void ReintentarNivel()
    {
        int ecenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(ecenaActual);
    }
}
