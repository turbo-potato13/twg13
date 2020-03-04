using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
  
    public void Strt()
    {
        SceneManager.LoadScene("intro");
    }
    public void Ext()
    {
        Application.Quit();
    }
    public void Settng()
    {
       SceneManager.LoadScene("Setting");
   
    }
    public void bck2()
    {
        SceneManager.LoadScene("Game");

    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");

    }
}
