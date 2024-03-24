using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JugadorVida : MonoBehaviour
{
    [SerializeField] public float vida;
    private Animator animator;
    

    // Barra de vida 
    [SerializeField] private float maximoVida;
    [SerializeField] Slider sliderVidas;


    private void Start()
    {
        animator = GetComponent<Animator>();
        vida = maximoVida;
       
    }
    private void Muerte()
    {
        animator.SetTrigger("Muerte");
        Invoke(nameof(ResetLevel), 2.0f);
    }
    public void TomarDaño(float daño)
    {
        vida -= daño;
        sliderVidas.value = vida;
        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Potion")
        {
            vida += 50;
            sliderVidas.value = vida;
            Destroy(collision.gameObject);
        }
    }

    // Cuando el jugador muera se activara esta funcion que identifica la escena actual y la vuelve a cargar para que todos los enemigos eliminados previamente vuelvan a su estado original >:)
    public void ResetLevel( ) 
    {
        // Obtenga la scena y cargela 
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Pantalla de muerte");
    }

    

}
