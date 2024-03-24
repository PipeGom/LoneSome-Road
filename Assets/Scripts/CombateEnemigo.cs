using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateEnemigo : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe; // posicion del controlador del golpe
    [SerializeField] private float radioGolpe; // porque el golpe es circular 
    [SerializeField] private float dañoGolpe;
    private Animator animator;

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
            if (animator.GetBool("atacar") && tiempoSiguienteAtaque <= 0)
            {
                Golpe();
                tiempoSiguienteAtaque = tiempoEntreAtaques;
            }

    }

    private void Golpe()
    {

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Player"))
            {
                colisionador.transform.GetComponent<JugadorVida>().TomarDaño(dañoGolpe);
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}

