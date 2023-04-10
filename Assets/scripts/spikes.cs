﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    public bool OnTrigger;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            OnTrigger = true;
        }
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<movement>();
            if (OnTrigger == true && col.GetComponent<movement>().boGroundChecks == true)
            {
                col.GetComponent<player>().TakeDamage();
                OnTrigger = false;
            }
        }
    }
}
