using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{

    public GameObject objetivo;
    public int vida = 100;

    public Animator Anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(objetivo.transform.position);
        Anim = GetComponent<Animator>();
        Anim.SetBool("isMoving",true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Objetivo")
        {
            Anim.SetBool("isMoving", false);
            Anim.SetTrigger("intObjetiveReache");
        }
    }

    public void Dañar()
    {
        objetivo?.GetComponent<objetivo>().RecibirDaño(40);
    }

    public void RecibirDaño(int daño = 5)
    {
        vida -= daño;
    }

}
