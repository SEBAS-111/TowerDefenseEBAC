using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TorreBase : MonoBehaviour
{
    public GameObject enemigo;
    public GameObject prefabBala;
    public List<GameObject> puntasCañon;

    private void Update()
    {
        if (enemigo != null)
        {
            Apuntar();
        }
    }

    public void Apuntar()
    {
        transform.LookAt(enemigo.transform);
    }

    public virtual void Disparar()
    {
        foreach (GameObject punta in puntasCañon)
        {
            var tempBala = Instantiate<GameObject>(prefabBala, punta.transform.position, Quaternion.identity);
            tempBala.GetComponent<Bala>().destino = enemigo.transform.position;
        }
    }
}
