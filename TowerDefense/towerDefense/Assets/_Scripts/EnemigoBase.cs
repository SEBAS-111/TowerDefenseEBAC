using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoBase : MonoBehaviour, IAtacante, IAtancable
{

    public GameObject objetivo;
    public int vida = 100;
    public int _daño = 5;
    public int recursosGanados = 200;

    public AdminJuego referenciaAdminJuego;
    public SpawnerEnemigo referenciaSpawner;
    public Animator Anim;

    private void OnEnable()
    {
        objetivo = GameObject.Find("Objetivo");
        referenciaAdminJuego = GameObject.Find("AdminJuego").GetComponent<AdminJuego>();
        referenciaSpawner = GameObject.Find("SpawnerEnemigo").GetComponent<SpawnerEnemigo>();
        objetivo.GetComponent<objetivo>().EnObjetivoDestruido += Detener;
    }

    private void OnDisable()
    {
        objetivo.GetComponent<objetivo>().EnObjetivoDestruido -= Detener;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(objetivo.transform.position);
        Anim = GetComponent<Animator>();
        Anim.SetBool("isMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Anim.SetTrigger("OnDead");
            GetComponent<NavMeshAgent>().SetDestination(transform.position);
            Destroy(gameObject, 3);
        }
    }

    public virtual void OnDestroy()
    {
        referenciaAdminJuego.ModificarRecursos(recursosGanados);
        referenciaSpawner.EnemigosGenerados.Remove(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Objetivo")
        {
            Anim.SetBool("isMoving", false);
            Anim.SetTrigger("intObjetiveReache");
        }
    }

    private void Detener()
    {
        Anim.SetTrigger("onObjetiveDestroy");
        GetComponent<NavMeshAgent>().SetDestination(transform.position);
    }

    public void Dañar(int daño)
    {
        if (daño == 0) daño = _daño;
        objetivo?.GetComponent<objetivo>().RecibirDaño(40);
    }

    public void RecibirDaño(int daño = 5)
    {
        vida -= daño;
    }

}
