using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Prueba1()
    {
        SceneManager.LoadScene("Prueba1");
    }

    public void Prueba2()
    {
        SceneManager.LoadScene("Prueba2");
    }

     public void Salir()
    {
        Application.Quit();
    }

}
