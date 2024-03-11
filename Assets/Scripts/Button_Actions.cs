using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Actions : MonoBehaviour
{
    public void Salir(){
        Debug.Log("Saliendo de la aplicacion");
        Application.Quit();
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Level Selection");
    }

    public void RecargarPagina(string scene){
        Debug.Log("Cambiando a: "+scene);
        SceneManager.LoadScene(scene);  
    }
}
