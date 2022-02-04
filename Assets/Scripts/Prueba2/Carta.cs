using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour
{
    public Color oculto; 

    Color miColor;
    Animator animator;
    Image imagen;
    bool ocultoB = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        imagen = GetComponent<Image>();
        miColor = imagen.color;
    }

    void Start()
    {        
        StartCoroutine(Ocultar());
    }   

    internal void Acomodar()
    {
        transform.position = GameManager.instance.spawnPoints[GameManager.instance.posiciones[transform.GetSiblingIndex()]].position;
    }

    internal void VoltearCarta()
    {
        animator.SetTrigger("voltearCarta");
    }

    internal void Desaparecer()
    {
        animator.SetTrigger("desaparecer");
    }

    public void ClicCarta()
    {        
        if(ocultoB)
        {
            //Debug.Log("voltear");
            animator.SetTrigger("voltearCarta");
            GameManager.instance.ClicCarta(gameObject, miColor);        
        }
    }

    public void CambiarColor()
    {
        if(ocultoB)
        {
            imagen.color = miColor;
        }
        else
        {
            imagen.color = oculto;
        }
        ocultoB = !ocultoB;
    }

    IEnumerator Ocultar()
    {
        yield return new WaitForSeconds(5f);
        VoltearCarta();
    }
    
}
