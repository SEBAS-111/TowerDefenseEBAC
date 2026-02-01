using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigo : MonoBehaviour
{
    public List<GameObject> preFabsEnemigos;
    public int oleada;
    public List<int> enemigosPorOleada;

    private int enemigosDuranteEstaOleada;

    public delegate void OleadaTerminada();
    public event OleadaTerminada EnOleadaTerminada;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oleada = 0;
        ConfigurarCantidadEnemigos();
        InstanciarEnemigo();
    }

    private void TerminarOla()
    {
        if (EnOleadaTerminada != null)
        {
            EnOleadaTerminada();
        }
    }

    public void ConfigurarCantidadEnemigos()
    {
        enemigosDuranteEstaOleada = enemigosPorOleada[oleada];
    }

    public void InstanciarEnemigo()
    {
        int indiceAleatoria = Random.Range(0, preFabsEnemigos.Count);
        Instantiate<GameObject>(preFabsEnemigos[indiceAleatoria], transform.position, Quaternion.identity);
        enemigosDuranteEstaOleada--;
        if (enemigosDuranteEstaOleada < 0)
        {
            oleada++;
            ConfigurarCantidadEnemigos();
            TerminarOla();
            return;
        }
        Invoke("InstanciarEnemigo", 2);
    }
}
