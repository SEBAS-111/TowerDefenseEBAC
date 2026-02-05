using UnityEngine;
using UnityEngine.AI;

public class Boss : EnemigoBase
{
    public void Awake()
    {
        vida = 200;
        _daño = 40;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        referenciaAdminJuego.enemigosJefeDerrotados++;
    }
}
