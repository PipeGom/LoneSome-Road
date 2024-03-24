using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class EnemigoVida : MonoBehaviour
{

    [SerializeField] public float vida;

    [SerializeField] public float vidaMaxima;

    private Animator animator;

    private void Start() 
    {
        animator = GetComponent<Animator>();
        vida = vidaMaxima;
    }

    private void Muerte()
    {

        animator.SetTrigger("Muerte");
        Invoke(nameof(Destruir),2.0f);
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            //animator.SetBool("Death", true);
            Muerte();
            
        }
    }

    private void Destruir() 
    {
        Destroy(gameObject);
    }

    /*public void ResetVida() 
    {
        vida = vidaMaxima;
    }*/

}
