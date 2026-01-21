using UnityEngine;

public class objetivo : MonoBehaviour
{

    public int vida = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    public void RecibirDaño(int daño = 20)
    {
        vida -= daño;
    }
}
