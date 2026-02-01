using UnityEngine;

public class objetivo : MonoBehaviour
{

    public int vida = 100;

    public delegate void ObjetivoDestruido();
    public event ObjetivoDestruido EnObjetivoDestruido;


    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {

            if (EnObjetivoDestruido != null)
            {
                EnObjetivoDestruido();
            }
            Destroy(this.gameObject);
        }

    }

    public void RecibirDaño(int daño = 20)
    {
        vida -= daño;
    }
}
