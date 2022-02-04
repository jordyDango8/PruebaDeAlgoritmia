using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Algoritmia : MonoBehaviour
{
    public TMP_InputField longitudArregloIF, baseDatosIF, evaluarIF;
    public TextMeshProUGUI resultadosT;

    string[] cadena = new string[20];
    int[] arreglo = new int[20], baseDatos = new int[20], evaluar = new int[20];
    int longitudBaseDatos, longitudEvaluar;
    string[,] resultado = new string[20, 2];

    public void Ejecutar()
    {        
        //Debug.Log("LA= " + longitudArregloIF.text);             
        ResetArrays();   

        Convertir(baseDatosIF, out longitudBaseDatos).CopyTo(baseDatos, 0);        
        Convertir(evaluarIF, out longitudEvaluar).CopyTo(evaluar, 0);
        //ImprimirArreglos();                                     
        ObtenerResultados();
        MostrarResultados();
    }

    int[] Convertir(TMP_InputField input, out int longitud)
    {
        cadena = input.text.Split(char.Parse(" "));
        longitud = cadena.Length;
                        
        for(int i = 0; i < longitud; i++)
        {                    
            arreglo[i] = int.Parse(cadena[i]);    
        }    
        return arreglo;
    }

    void ObtenerResultados()
    {
        for(int j = 0; j < longitudEvaluar; j++)
        {
            for(int i = 0; i < longitudBaseDatos; i++)
            {
                //Debug.Log("iteracion " + i);            
                if(evaluar[j] < baseDatos[i])
                {    
                    if(i == 0)
                    {                        
                        //Debug.Log("X " + baseDatos[i]);
                        resultado[j, 0] = "X";
                        resultado[j, 1] = baseDatos[i].ToString();
                    }                   
                    else
                    {
                        //Debug.Log(baseDatos[i-1] + " " + baseDatos[i]);
                        resultado[j, 0] = baseDatos[i-1].ToString();
                        resultado[j, 1] = baseDatos[i].ToString();
                    }                                                                             
                    break;
                }
                else if(evaluar[j] == baseDatos[i])
                {
                    if(longitudBaseDatos == 1)
                    {
                        //Debug.Log("X " + "X");
                        resultado[j, 0] = "X";
                        resultado[j, 1] = "X";
                    }
                    else
                    {
                        if(i == 0)
                        {                        
                            //Debug.Log("X " + baseDatos[i+1]);
                            resultado[j, 0] = "X";
                            resultado[j, 1] = baseDatos[i+1].ToString();
                        }
                        else if(i == longitudBaseDatos - 1)
                        {                        
                            //Debug.Log(baseDatos[i-1] + " X");
                            resultado[j, 0] = baseDatos[i-1].ToString();
                            resultado[j, 1] = "X";
                        }
                        else
                        {
                            //Debug.Log(baseDatos[i-1] + " " + baseDatos[i+1]);
                            resultado[j, 0] = baseDatos[i-1].ToString();
                            resultado[j, 1] = baseDatos[i+1].ToString();
                        }
                    }                    
                    break;
                }         
                else if(i == longitudBaseDatos - 1)                        
                {
                    //Debug.Log(baseDatos[i] + " X");
                    resultado[j, 0] = baseDatos[i].ToString();
                    resultado[j, 1] = "X";
                }  
            }    
        }       
        //Debug.Log("termine");
    }

    void MostrarResultados()
    {
        resultadosT.text = "Resultado\n";
        for(int i = 0; i < longitudEvaluar; i++)
        {
            resultadosT.text += resultado[i, 0] + " " + resultado[i, 1] + "\n";
        }
    }

    void ResetArrays()
    {
        Array.Clear(cadena, 0, cadena.Length);
        Array.Clear(baseDatos, 0, baseDatos.Length);
        Array.Clear(evaluar, 0, evaluar.Length);  
        Array.Clear(resultado, 0, resultado.Length);            
    }

    void ImprimirArreglos()
    {
        for(int i = 0; i < longitudBaseDatos; i++)
        {        
            Debug.Log("BD " + i + " " + baseDatos[i]);    
        }   
        
        for(int i = 0; i < longitudEvaluar; i++)
        {        
            Debug.Log("E " + i + " " + evaluar[i]);    
        } 
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}