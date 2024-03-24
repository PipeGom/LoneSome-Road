using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe; // posicion del controlador del golpe
    [SerializeField] private float radioGolpe; // porque el golpe es circular 
    [SerializeField] private float dañoGolpe;
    private Animator animator;

    /// evitar que ataque demasiado rapido 
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;


    

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1") && tiempoSiguienteAtaque <= 0)
        {
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
    }

    private void Golpe() 
    {
        animator.SetTrigger("Golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo")) 
            {
                colisionador.transform.GetComponent<EnemigoVida>().TomarDaño(dañoGolpe);
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
