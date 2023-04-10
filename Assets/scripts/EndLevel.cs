using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public GameObject UI;
    public GameObject GameUI;
    public int intNextLevel;
    public SpriteRenderer spDoor1;
    public SpriteRenderer spDoor2;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("LEVEL COMPLEET");
            spDoor1.color = Color.black;
            spDoor2.color = Color.black;
            UI.SetActive(false);
            GameUI.SetActive(true);
            col.gameObject.SetActive(false);
        }
    }

    public void nextlevel(){
        SceneManager.LoadScene(intNextLevel);
        }

}
