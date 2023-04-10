using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuUI : MonoBehaviour
{
    public GameObject menu;
    public GameObject levels;


    public void layermenu1()
    {
        menu.SetActive(false);
        levels.SetActive(true);
    }
    public void layerlevel2()
    {
        menu.SetActive(true);
        levels.SetActive(false);
    }

    public void level1()
    {
        SceneManager.LoadScene(1);
    }

    public void level2()
    {
        SceneManager.LoadScene(2);
    }
    public void level3()
    {
        SceneManager.LoadScene(3);
    }
    public void level4()
    {
        SceneManager.LoadScene(4);
    }
    public void level5()
    {
        SceneManager.LoadScene(5);
    }
    public void level6()
    {
        SceneManager.LoadScene(6);
    }
    public void level7()
    {
        SceneManager.LoadScene(7);
    }
    public void level8()
    {
        SceneManager.LoadScene(8);
    }
    public void level9()
    {
        SceneManager.LoadScene(9);
    }
    public void level10()
    {
        SceneManager.LoadScene(10);
    }
    public void level11()
    {
        SceneManager.LoadScene(11);
    }
    public void level12()
    {
        SceneManager.LoadScene(12);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
