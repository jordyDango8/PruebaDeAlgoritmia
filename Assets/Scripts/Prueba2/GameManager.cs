using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI intentosRestantesT, mensajeT;
    public GameObject impedirClicGO, gameOver;
    public GameObject[] cartas;
    public Transform[] spawnPoints;

    internal int[] posiciones = new int[24];

    Color colorAnterior;
    GameObject cartaAnterior;
    bool primerIntentoB = true;
    int intentosRestantes = 12, pares = 0;

    void Awake()
    {        
        instance = this;        
    }

    void Start()
    {        
        GenerarPosiciones();
        AsignarPosiciones();
        StartCoroutine(Iniciar());
    }

    void GenerarPosiciones()
    {
        for(int i = 0; i < 24; i++)
        {
            posiciones[i] = Random.Range(0, 24);
            for(int j = 1; j <= i; j++)
            {
                if(posiciones[j-1] == posiciones[i])
                {
                    posiciones[i] = Random.Range(0, 24);
                    j = 0;                                         
                }
            }
        }
        //for(int i = 0; i < 24; i++)
        //{
        //    Debug.Log(posiciones[i]);
        //}        
    }

    void AsignarPosiciones()
    {
        foreach (GameObject carta in cartas)
        {            
            carta.GetComponent<Carta>().Acomodar();
        }
    }

    IEnumerator Iniciar()
    {
        yield return new WaitForSeconds(5);
        impedirClicGO.SetActive(false);
        intentosRestantesT.text = "Intentos Restantes " + intentosRestantes.ToString();
    }

    internal void ClicCarta(GameObject cartaActual, Color colorActual)
    {
        StartCoroutine(ClicCartaCR(cartaActual, colorActual));        
    }    

    IEnumerator ClicCartaCR(GameObject cartaActual, Color colorActual)
    {
        impedirClicGO.SetActive(true);
        
        yield return new WaitForSeconds(1f);
        impedirClicGO.SetActive(false);
        if(primerIntentoB)
        {
            colorAnterior = colorActual;
            cartaAnterior = cartaActual;
        }
        else
        {
            if(colorAnterior == colorActual)
            {
                //Debug.Log("par");
                cartaAnterior.GetComponent<Carta>().Desaparecer();
                cartaActual.GetComponent<Carta>().Desaparecer();
                intentosRestantes += 1;    
                pares += 1;            
            }            
            else
            {
                //Debug.Log("error");
                cartaAnterior.GetComponent<Carta>().VoltearCarta();
                cartaActual.GetComponent<Carta>().VoltearCarta();
                intentosRestantes -= 1;
            }
            intentosRestantesT.text = "Intentos Restantes " + intentosRestantes.ToString();
            RevisarEstadoJuego();
        }
        primerIntentoB = !primerIntentoB;
    }

    void RevisarEstadoJuego()
    {
        if(pares == 12)
        {
            //Debug.Log("ganaste");
            gameOver.SetActive(true);
            mensajeT.text = "GANASTE! :)";
        }
        if(intentosRestantes == 0)
        {
            //Debug.Log("perdiste");
            gameOver.SetActive(true);
            mensajeT.text = "PERDISTE! :(";
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
