using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevel : MonoBehaviour
{
    public int level;

    public void restart()
    {
        SceneManager.LoadScene(level);
    }

    public void Pauze()
    {
        Time.timeScale = 0;
    }
    public void resume()
    {
        Time.timeScale = 1;
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
    public void playerrestart(int scene)
    {
        SceneManager.LoadScene(level);
    }
}
