using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float floSpeed;
    public bool boDirection;

    void Update()
    {
        if (boDirection == false)
        {
            transform.Translate(new Vector3((floSpeed), 0, 0) * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(-(floSpeed), 0, 0) * Time.deltaTime);

        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            Destroy(gameObject);
        }
    }
}
