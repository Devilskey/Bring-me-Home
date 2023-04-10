using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float flohealth = 10;
    public AudioSource Explosion;
    void Start()
    {
        
    }


    void Update()
    {
        if(flohealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "bullet")
        {
            Explosion.Play();
            flohealth -= 10;
            Destroy(col.gameObject);
        }
    }
}
