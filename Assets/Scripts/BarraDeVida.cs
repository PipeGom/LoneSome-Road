using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarraDeVida : MonoBehaviour
{
    // Start is called before the first frame update

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>(); // Se obtiene la variable del slider 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiarVidaMaxima(float vidaMaxima) 
    {
        slider.maxValue = vidaMaxima; 

    }

    public void CambiarVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida;
    }
    public void InicilizarBarradevida(float cantidadVida) 
    {
        CambiarVidaActual(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}
