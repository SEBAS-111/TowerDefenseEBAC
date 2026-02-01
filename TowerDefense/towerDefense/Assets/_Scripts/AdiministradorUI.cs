using UnityEngine;
using UnityEngine.SceneManagement;

public class AdiministradorUI : MonoBehaviour
{
    public GameObject CanvasPrincipal;
    public GameObject MenuGamneOver;
    public GameObject referenciasSpawner;
    public GameObject referenciasObjetivo;



    private void OnEnable()
    {
        objetivo obj = referenciasObjetivo.GetComponent<objetivo>();
        if (obj != null)
        {
            obj.EnObjetivoDestruido += MostrarMenuGameover;
        }
    }

    private void OnDisable()
    {
        objetivo obj = referenciasObjetivo.GetComponent<objetivo>();
        if (obj != null)
        {
            obj.EnObjetivoDestruido -= MostrarMenuGameover;
        }
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
