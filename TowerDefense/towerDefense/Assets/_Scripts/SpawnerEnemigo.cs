using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigo : MonoBehaviour
{
    public List<GameObject> preFabsEnemigos;
    public int oleada;
    public List<int> enemigosPorOleada;

    private int enemigosDuranteEstaOleada;


    public bool laOleadaHaIniciado;
    public List<GameObject> EnemigosGenerados;


    public delegate void EstadoOleadas();
    public event EstadoOleadas EnOleadaIniciada;
    public event EstadoOleadas EnOleadaTerminada;
    public event EstadoOleadas EnOleadaGanada;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oleada = 0;
    }

    public void FixedUpdate()
    {
        if (laOleadaHaIniciado && EnemigosGenerados.Count == 0)
        {
            GanarOla();
        }
    }

    public void EmpezarOleada()
    {
        laOleadaHaIniciado = true;
        if (EnOleadaIniciada != null)
        {
            EnOleadaIniciada();
        }
        ConfigurarCantidadEnemigos();
        InstanciarEnemigo();
    }
    private void GanarOla()
    {
        if (laOleadaHaIniciado && EnOleadaGanada != null)
        {
            EnOleadaGanada();
            laOleadaHaIniciado = false;
        }
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
        var enemigoTemporal = Instantiate<GameObject>(preFabsEnemigos[indiceAleatoria], transform.position, Quaternion.identity);
        EnemigosGenerados.Add(enemigoTemporal);

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
